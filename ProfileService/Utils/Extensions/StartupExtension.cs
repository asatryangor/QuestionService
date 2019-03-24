using Microsoft.Extensions.DependencyInjection;
using ProfileService.Core.Services.ImageService;
using ProfileService.Core.Services.ProfileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Utils.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileService, Core.Services.ProfileService.ProfileService>();
            services.AddScoped<IImageService, ImageService>();
        }
    }
}
