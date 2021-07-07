using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Docs.Samples;

namespace gepaplexxPraktikantenAnwendung.Hello
{
    public class HelloCheck : Controller
    {
        public IActionResult Details(string name)
        {
            return ControllerContext.MyDisplayRouteInfo(name);
        }
        public void Apply(ControllerModel controller)
        {
            var hasRouteAttributes = controller.Selectors.Any(selector =>
                                                    selector.AttributeRouteModel != null);
            if (hasRouteAttributes)
            {
                return;
            }
        }
    }
}


