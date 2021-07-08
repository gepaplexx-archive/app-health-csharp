using gepaplexxPraktikantenAnwendung.Break;
using gepaplexxPraktikantenAnwendung.ErrorResponse;
using gepaplexxPraktikantenAnwendung.Health;
using gepaplexxPraktikantenAnwendung.Hello;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHealthChecks()
            .AddCheck<ExampleHealthCheck>("example_health_check");
            services.AddStartupTask<BreakStartupTask>();
            services.AddHelloTask<HelloStartup>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");                
            });

            app.UseMiddleware<ErrorResponseClass>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("BreakMethode","{Controller=break}/{action=app}/{sec}");

            });

            app.UseMiddleware<ErrorResponseClass>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("HelloMethode","{Controller=hello}/{action=app}/{name}");
            });
        }
    }
}
