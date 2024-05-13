using Blazored.LocalStorage;
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
                 .PostAsync($"http://localhost:5000/api/Account/register",
                 Generics.GenerateStringContent(
                 Generics.SerializeObj(userDTO)));

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new GeneralResponse(false, "Error occured. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<GeneralResponse>(apiResponse);
        }

        

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            var response = await httpClient
               .PostAsync($"http://localhost:5000/api/Account/login",
               Generics.GenerateStringContent(
               Generics.SerializeObj(loginDTO)));

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new LoginResponse(false, null!, "Error occured. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<LoginResponse>(apiResponse); 

        }

        


    }
}
