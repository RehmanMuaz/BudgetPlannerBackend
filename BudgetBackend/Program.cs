using BudgetBackend.Models;
using BudgetBackend.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    }).AddCookie()
    .AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection =
            config.GetSection("Authentication:Google");
        options.ClientId = googleAuthNSection["ClientId"] ?? throw new InvalidOperationException("ClientID not found");
        options.ClientSecret = googleAuthNSection["ClientSecret"] ?? throw new InvalidOperationException("ClientSecret not found");
        options.CallbackPath = "/auth/google/callback";
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    });

builder.Services.AddDbContext<BudgetContext>(options => options.UseNpgsql(config.GetConnectionString("DBConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();