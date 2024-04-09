using Microsoft.EntityFrameworkCore;
using TicmansoWebAPI.Models;
using Microsoft.Net.Http.Headers;
using TicmansoWebAPI.Identity;
using Microsoft.AspNetCore.Identity;
using TicmansoWebAPI.Model;

var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
       policy =>
       {
           policy.WithOrigins("http://localhost:5130", "https://localhost:7144/api/Ticmanso/users")
                 .AllowAnyHeader()
                 .AllowAnyOrigin()
                 .AllowAnyMethod();
       });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TicmansoDevContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringSQL3"));
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<TicmansoDevContext>()
    .AddDefaultTokenProviders();

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

using (var scope = app.Services.CreateScope()) {

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Support", "User" };

    foreach (var role in roles) {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

}

using (var scope = app.Services.CreateScope())
{

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "admin@ticmanso.com";
    string password = "adm1n";



    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.Email = email;
        user.UserName = email;
        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
    
    
}

app.Run();
//https://ebuah.uah.es/dspace/bitstream/handle/10017/53453/TFG_Garcia_Lopez_2022.pdf?sequence=1&isAllowed=y