using Azure;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using TicmansoV2.Shared;
using TicmansoV2.Shared.Contracts;
using TicmansoV2.Shared.GenericModels;
using static TicmansoV2.Shared.ServiceResponses;


namespace TicmansoV2.Services
{
    public class AccountService : IUserAccount
    {
        public AccountService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public async Task<GeneralResponse> CreateAccount(ApplicationUserDTO userDTO)
        {
            var response = await httpClient
                 .PostAsync($"api/Account/register",
                 Generics.GenerateStringContent(
                 Generics.SerializeObj(userDTO)));

            if (!response.IsSuccessStatusCode)
                return new GeneralResponse(false, "Ha ocurrido un error, por favor intentelo más tarde");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<GeneralResponse>(apiResponse);
        }        

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            var response = new HttpResponseMessage();
            try
            {
                response = await httpClient
               .PostAsync($"api/Account/login",
               Generics.GenerateStringContent(
               Generics.SerializeObj(loginDTO)));
            }
            catch (Exception)
            {
                Console.WriteLine("No se ha podido realizar el inicio de sesion",Severity.Error);
            }
             
          
            if (!response.IsSuccessStatusCode)
                return new LoginResponse(false, null!, "Ha ocurrido un error, por favor intentelo más tarde");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<LoginResponse>(apiResponse); 

        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var response = await httpClient
                .PostAsync($"api/Account/change-password",
                Generics.GenerateStringContent(
                Generics.SerializeObj(changePasswordDTO)));

            
            if (!response.IsSuccessStatusCode)
                return new ChangePasswordResponse(false, "Ha ocurrido un error, por favor inténtelo más tarde");
            
            var apiResponse = await response.Content.ReadAsStringAsync();
            
            return Generics.DeserializeJsonString<ChangePasswordResponse>(apiResponse);
        }

        public async Task<GeneralResponse> ForgotPassword(string email)
        {
            var response = await httpClient
                .PostAsync($"api/Account/forgot-password?email={email}", null);

            if (!response.IsSuccessStatusCode)
                return new GeneralResponse(false, "Ha ocurrido un error, por favor inténtelo más tarde");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<GeneralResponse>(apiResponse);
        }

        public async Task<GeneralResponse> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var response = await httpClient
                .PostAsync($"api/Account/reset-password",
                Generics.GenerateStringContent(
                Generics.SerializeObj(resetPasswordDTO)));

            if (!response.IsSuccessStatusCode)
                return new GeneralResponse(false, "Ha ocurrido un error, por favor inténtelo más tarde");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<GeneralResponse>(apiResponse);
        }

        public async Task<GeneralResponse> DeleteAccount(string userId)
        {
            var response = await httpClient
                .DeleteAsync($"api/Account/delete-account/{userId}");
            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<GeneralResponse>(apiResponse);
        }
    }
}
