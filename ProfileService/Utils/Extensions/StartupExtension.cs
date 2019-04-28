using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProfileService.Core.Services.ImageService;
using ProfileService.Core.Services.ProfileService;
using ProfileService.Utils.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileService.Utils.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(new[]
                        {
                            "http://localhost:3000"
                        }
                    )
                );
            });
        }
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
            services.AddScoped<IProfileService, Core.Services.ProfileService.ProfileService>();
            services.AddScoped<IImageService, ImageService>();
        }
    }
}
