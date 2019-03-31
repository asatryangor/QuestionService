using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using QuestionService.Core.Services.QuestionService;
using QuestionService.Utils.Settings;
using System.Text;

namespace QuestionService.Utils.Extensions
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
            //services.AddScoped<IProfileService, Core.Services.ProfileService.ProfileService>();
            services.AddScoped<IQuestionService, Core.Services.QuestionService.QuestionService>();
        }
    }
}
