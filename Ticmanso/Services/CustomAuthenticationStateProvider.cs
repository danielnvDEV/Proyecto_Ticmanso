using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace Ticmanso.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private readonly NavigationManager _navigationManager;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage, NavigationManager navigationManager)
        {
            _sessionStorage = sessionStorage;
            _navigationManager = navigationManager;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _sessionStorage.GetItemAsync<string>("token");

            var identity = string.IsNullOrEmpty(token)
                ? new ClaimsIdentity()
                : new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.NameIdentifier, out object id);
            keyValuePairs.TryGetValue(ClaimTypes.Name, out object name);
            keyValuePairs.TryGetValue(ClaimTypes.Surname, out object surname);
            keyValuePairs.TryGetValue(ClaimTypes.Email, out object email);
            keyValuePairs.TryGetValue(ClaimTypes.UserData, out object companyId);
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object role);

            if (id != null)
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            }

            if (name != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, name.ToString()));
            }

            if (surname != null)
            {
                claims.Add(new Claim(ClaimTypes.Surname, surname.ToString()));
            }

            if (email != null)
            {
                claims.Add(new Claim(ClaimTypes.Email, email.ToString()));
            }

            if (companyId != null)
            {
                claims.Add(new Claim(ClaimTypes.UserData, companyId.ToString()));
            }

            if (role != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }


}
