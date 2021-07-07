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
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();         
            
        }
        public IActionResult Details1(string name)
        {
            return ControllerContext.MyDisplayRouteInfo(name);
        }
    }
}
