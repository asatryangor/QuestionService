using AuthService.Core.Services.AuthService;
using AuthService.Core.Services.RoleService;
using AuthService.Utils.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthService.Utils.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterAuth(this IServiceCollection services, AuthSettings authSettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
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
                })
                .AddCookie()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = authSettings.Facebook.AppId;
                    facebookOptions.AppSecret = authSettings.Facebook.AppSecret;
                    facebookOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                });
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
            services.AddScoped<IAuthService, Core.Services.AuthService.AuthService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
