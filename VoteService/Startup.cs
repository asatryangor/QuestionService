using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoteService.Data.Context;
using VoteService.Utils.Extensions;
using VoteService.Utils.Settings;

namespace VoteService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AuthSettings = configuration.GetSettings<AuthSettings>();
        }

        public IConfiguration Configuration { get; }
        public AuthSettings AuthSettings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VoteContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddAutoMapper();
            services.AddCors();
            services.RegisterAuth(AuthSettings);
            services.RegisterServices();
            services.AddMvc();
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
