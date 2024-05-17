using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TicmansoV2;
using TicmansoV2.Authentication;
using TicmansoV2.Services;
using TicmansoV2.Shared.Contracts;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://www.nascasadani.duckdns.org:7291") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7291") });

builder.Services.AddMudServices();
builder.Services.AddOptions();


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccount, AccountService>();

await builder.Build().RunAsync();
