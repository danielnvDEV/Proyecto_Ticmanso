using Blazored.LocalStorage;
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

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new GeneralResponse(false, "Ha ocurrido un error, por favor intentelo más tarde");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<GeneralResponse>(apiResponse);
        }

        

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            var response = await httpClient
               .PostAsync($"api/Account/login",
               Generics.GenerateStringContent(
               Generics.SerializeObj(loginDTO)));

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new LoginResponse(false, null!, "Ha ocurrido un error, por favor intentelo más tarde");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<LoginResponse>(apiResponse); 

        }

        public async Task<GeneralResponse> ChangePassword(string userId, string currentPassword, string newPassword)
        {
            var changePasswordDTO = new ChangePasswordDTO
            {
                UserId = userId,
                CurrentPassword = currentPassword,
                NewPassword = newPassword
            };

            var response = await httpClient.PostAsJsonAsync("api/account/change-password", changePasswordDTO);
            return await response.Content.ReadFromJsonAsync<GeneralResponse>();
        }


    }
}
