
using gepaplexxPraktikantenAnwendung.Health;

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
        public bool IsDownOrPaused { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            IsDownOrPaused = false;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHealthChecks()
            .AddCheck<ExampleHealthCheck>("example_health_check");


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


            app.UseEndpoints(endpoints =>
            {
                IsDownOrPaused = true;
                endpoints.MapControllerRoute("BreakMethode", "{Controller=App}/{action=breakapp}/{sec}");

            });

            if (IsDownOrPaused == false)
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("HelloMethode", "{Controller=App}/{action=helloapp}/{name}");
                });
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("TermianteMethode", "{Controller=App}/{action=terminateapp}");
                IsDownOrPaused = true;
            });
        }
    }
}
