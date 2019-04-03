using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VoteService.Core.Services.VoteService;
using VoteService.Utils.Settings;

namespace VoteService.Utils.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterAuth(this IServiceCollection services, AuthSettings authSettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = authSettings.Issuer,
                        ValidAudience = authSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.SecretKey))
                    };
                });
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IVoteService, Core.Services.VoteService.VoteService>();
        }
    }
}
