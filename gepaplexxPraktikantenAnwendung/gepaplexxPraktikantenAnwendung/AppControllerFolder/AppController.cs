using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.AppControllerFolder
{
    public class AppController: Controller
    {
        

        
        
        
        public async Task<IActionResult> helloapp(int name)
        {
            if (AppControllerResources.IsDownOrPaused == false) {
                Console.WriteLine("Success");
                string helloText;


                helloText = $"Hello: {name}.";

                return Ok(helloText);
            }
            else
            {
                string breakText = "App is currently down or paused";
                return BadRequest(breakText);
            }
        }
        public async Task<IActionResult> breakapp(int sec)
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
            await response.WriteAsync("Service Unavailable");

            Thread.Sleep(sec * 1000);
            
            //pauseFor.Stop();

            //response.StatusCode = 200;
            //waitFor(sec);
            //response.StatusCode = 200;
            return Ok(breakText);
        }

        public IActionResult terminateapp()
        {
            string terminateText = "The Application is now terminated";
            AppControllerResources.IsDownOrPaused = true;


            return Ok(terminateText);
        }

        public async Task<IActionResult> healthapp(int name)
        {
            


            return NoContent();
        }
    }
}
