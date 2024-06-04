using TicmansoV2.Shared;
using static TicmansoV2.Shared.ServiceResponses;

namespace TicmansoV2.Shared.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(ApplicationUserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
        Task<ChangePasswordResponse> ChangePassword(ChangePasswordDTO changePasswordDTO);
        Task<GeneralResponse> ForgotPassword(string email);
        Task<GeneralResponse> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<GeneralResponse> DeleteAccount(string userId);

    }
}
