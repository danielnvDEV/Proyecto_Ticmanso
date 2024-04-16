using TicmansoV2.Shared;
using static TicmansoV2.Shared.ServiceResponses;

namespace TicmansoV2.Shared.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(ApplicationUserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
