using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Docs.Samples;

namespace gepaplexxPraktikantenAnwendung.Hello
{
    public class HelloStartup : Controller
    {
        [Route("[controller]/[name?]")]
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "/hello",
                    pattern: "{controller=Hello}/{name}");
            });

            IActionResult Details(string name)
            {
                return ControllerContext.MyDisplayRouteInfo(name);
            }
        }
    }
}
