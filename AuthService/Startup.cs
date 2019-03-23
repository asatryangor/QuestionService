using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Data.Context;
using AuthService.Utils.Extensions;
using AuthService.Utils.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AuthSettings = configuration.GetSettings<AuthSettings>();
        }

        public IConfiguration Configuration { get; }
        private AuthSettings AuthSettings { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddAutoMapper();
            services.AddCors();
            services.RegisterAuth(AuthSettings);
            services.RegisterServices();
            services.AddMvc();
            services.Configure<AuthSettings>(Configuration.GetSection(nameof(AuthSettings)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
