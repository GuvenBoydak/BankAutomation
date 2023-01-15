using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Bank.Application.DTOs.Token;
using Bank.Application.Interfaces.Services;
using Bank.Infrastructure.Services.Jwt;
using Microsoft.Extensions.Configuration;

namespace Bank.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection service,IConfiguration configuration)
    {
        service.AddScoped<ITokenHelper, TokenHelper>();
        
        TokenOption tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOption>();

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                };
            });

        return service;
    }
}