using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Docs.Samples;
using System.Threading;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace gepaplexxPraktikantenAnwendung.Hello
{
    public class HelloStartup : Controller
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("/hello", "{controller=Hello}/{action=Index}/{name}");
            });

        }
        public IActionResult Details1(string name)
        {
            return ControllerContext.MyDisplayRouteInfo("Hello: ",name);
        }
    }
}
 
