using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicmansoV2.Shared;
using TicmansoV2.Shared.Contracts;
using TicmansoWebApiV2.Context;

using static TicmansoV2.Shared.ServiceResponses;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.Extensions;
using TicmansoWebApiV2.Controllers;

namespace TicmansoWebApiV2.Repositories
{
    public class AccountRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, IActionContextAccessor _actionContextAccessor,IHttpContextAccessor httpContextAccessor
        , LinkGenerator linkGenerator, EmailController emailController) : IUserAccount
        
    {
        private readonly HttpContext _httpContext;
        private readonly IUrlHelperFactory urlHelperFactory;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelper UrlHelper;
        private readonly HttpClient httpClient;
        //private readonly EmailController emailController;


        public async Task<GeneralResponse> CreateAccount(ApplicationUserDTO userDTO)
        {
            if (userDTO is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new ApplicationUser()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = userDTO.PasswordHash,
                UserName = userDTO.Email
            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User registered already");

            var createUser = await userManager.CreateAsync(newUser!, userDTO.PasswordHash);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error occured.. please try again");


            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created");
            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null)
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });

                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true, "Account Created");
            }
        }

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return new LoginResponse(false, null!, "Login container is empty");

            var getUser = await userManager.FindByEmailAsync(loginDTO.Email);
            if (getUser is null)
                return new LoginResponse(false, null!, "User not found");

            bool checkUserPasswords = await userManager.CheckPasswordAsync(getUser, loginDTO.Password);
            if (!checkUserPasswords)
                return new LoginResponse(false, null!, "Invalid email/password");

            var getUserRole = await userManager.GetRolesAsync(getUser);
            var userSession = new UserSession(getUser.Id, getUser.Name, getUser.Email, getUserRole.First(), getUser.Company?.ToString() ?? string.Empty);
            string token = GenerateToken(userSession);
            return new LoginResponse(true, token!, "Login completed");
        }

        private string GenerateToken(UserSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.UserData, user.Company),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var user = await userManager.FindByEmailAsync(changePasswordDTO.Email);
            if (user == null)
            {
                return new ChangePasswordResponse(false, "Usuario no encontrado");
            }

            var result = await userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);
            if (result.Succeeded)
            {
                return new ChangePasswordResponse(true, "Se ha cambiado la contrasena correctamente");
            }
            else
            {
                return new ChangePasswordResponse(false, "Ha ocurrido un error, por favor inténtelo más tarde");
            }
        }

        public async Task<GeneralResponse> ForgotPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return new GeneralResponse(false, "Usuario no encontrado");

            var token = "";

            try
            {
                token = await userManager.GeneratePasswordResetTokenAsync(user);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            var actionContext = _actionContextAccessor.ActionContext;
            
            var resetLink = "";
                      
            var urlHelper = new UrlHelper(actionContext);

            try
            {
                var httpContext = new DefaultHttpContext();
                httpContext.Request.Scheme = "http";
                httpContext.Request.Host = new HostString("ticmanso.com:7174");
                //httpContext.Request.PathBase = "/reset-password";

                resetLink = linkGenerator.GetUriByAction(
                               httpContext,
                               //page: "/reset-password",
                               action: "ResetPassword",
                               controller: "Account",
                               values: new { email, token });
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            

            EmailDTO emailData = new EmailDTO();

            emailData.Body = $"<p>Hola {user.UserName},</p><p>Para restablecer tu contraseña, haz clic en el siguiente enlace:</p><p><a href='{resetLink}'>Restablecer contraseña</a></p>";
            emailData.Subject = "Pasos a seguir para restablecer la contraseña";
            emailData.ToEmail = email;
            
            try
            {
              var apiResponse = await emailController.SendEmail(emailData);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            

            return new GeneralResponse(true, "Se ha enviado un correo electrónico con las instrucciones para restablecer la contraseña");
        }

        public async Task<GeneralResponse> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user == null)
                return new GeneralResponse(false, "Usuario no encontrado");

            var result = await userManager.ResetPasswordAsync(user, resetPasswordDTO.Token, resetPasswordDTO.NewPassword);
            if (result.Succeeded)
                return new GeneralResponse(true, "La contraseña se ha restablecido correctamente");
            else
                return new GeneralResponse(false, "Ha ocurrido un error al restablecer la contraseña");
        }
    }
}