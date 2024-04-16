
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicmansoWebAPI;
using TicmansoWebAPI.Models;


var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
       policy =>
       {
           policy.WithOrigins("http://localhost:5130", "https://localhost:7144/api/Ticmanso/users", "http://localhost:5000")
                 .AllowAnyHeader()
                 .AllowAnyOrigin()
                 //.AllowCredentials()
                 .AllowAnyMethod();
                 
        });
});

builder.Services.AddControllers();
builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TicmansoProContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringSQL"));
});
builder.Services.AddSignalR();
builder.Services.AddAuthorizationCore();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection(); 

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins); 

app.UseAuthorization(); 

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToFile("index.html");
    endpoints.MapHub<SignalRHub>("/signalRHub");
});

app.Run();

//https://ebuah.uah.es/dspace/bitstream/handle/10017/53453/TFG_Garcia_Lopez_2022.pdf?sequence=1&isAllowed=y