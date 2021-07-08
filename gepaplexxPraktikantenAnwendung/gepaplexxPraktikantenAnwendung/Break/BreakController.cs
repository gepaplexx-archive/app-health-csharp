using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace gepaplexxPraktikantenAnwendung.Break
{
    public class BreakController : Controller
    {
        public async Task<IActionResult> appAsync(int sec)
        {

            Console.WriteLine("Success");
            string breakText;

            

            //Timer pauseFor = new Timer();
            //pauseFor.Interval = sec * 1000;
            //pauseFor.Start();

            breakText = $"The Application is paused for {sec} seconds";

            var response = HttpContext.Response;
            response.StatusCode = 423;
            response.Headers["Retry-After"] = "10";
           // await response.WriteAsync("Service Unavailable");

            Thread.Sleep(sec * 1000);

            //pauseFor.Stop();

            //response.StatusCode = 200;
            //waitFor(sec);
            //response.StatusCode = 200;
            return BadRequest(breakText);
        }
    }
}
