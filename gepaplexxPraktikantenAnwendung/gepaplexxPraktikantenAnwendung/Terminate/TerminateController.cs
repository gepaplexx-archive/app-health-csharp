using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.Terminate
{
    public class TerminateController : Controller
    {
        public async Task<IActionResult> appAsync()
        {

            Console.WriteLine("Success");
            string breakText;


            //Timer pauseFor = new Timer();
            //pauseFor.Interval = sec * 1000;
            //pauseFor.Start();

            breakText = $"The Application got Terminated";

            var response = HttpContext.Response;
            response.StatusCode = 423;
            response.Headers["Retry-After"] = "10";
            // await response.WriteAsync("Service Unavailable");

            //pauseFor.Stop();

            //response.StatusCode = 200;
            //waitFor(sec);
            //response.StatusCode = 200;
            return BadRequest(breakText);
        }

    }
}
