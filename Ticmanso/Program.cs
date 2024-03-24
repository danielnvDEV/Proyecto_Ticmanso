using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Ticmanso;
using TicmansoWebAPI.Models;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddDbContext<TicmansoProContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("StringSQL"));
//}

//);

await builder.Build().RunAsync();




