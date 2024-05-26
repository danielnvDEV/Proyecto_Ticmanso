using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;
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

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var response = await httpClient
                .PostAsync($"api/Account/change-password",
                Generics.GenerateStringContent(
                Generics.SerializeObj(changePasswordDTO)));

            
            if (!response.IsSuccessStatusCode)
                return new ChangePasswordResponse(false, "Ha ocurrido un error, por favor inténtelo más tarde");

            // Leer el contenido de la respuesta
            var apiResponse = await response.Content.ReadAsStringAsync();

            // Deserializar la respuesta en un objeto ChangePasswordResponse
            return Generics.DeserializeJsonString<ChangePasswordResponse>(apiResponse);
        }


    }
}
