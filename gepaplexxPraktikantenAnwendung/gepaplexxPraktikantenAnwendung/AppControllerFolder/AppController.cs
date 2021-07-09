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



        [Route("app/helloapp")]
        [Route ("app/helloapp/{greeting}")]
        public async Task<IActionResult> helloapp(string greeting)
        {
            
            if (AppControllerResources.IsDownOrPaused == false) {

                if (string.IsNullOrWhiteSpace(greeting) == true)
                {
                    return Ok("Pleas enter a name");
                }
                string helloText;


                helloText = $"Hello {greeting}";

                return Ok(helloText);
            }
            else
            {
                string breakText = "App is currently down or paused";
                return BadRequest(breakText);
            }
        }
        [Route("app/breakapp")]
        [Route("app/breakapp/{sec}")]
        public async Task<IActionResult> breakapp(int sec)
        {

            if (sec <=0)
            {
                return BadRequest("Seconds must be higher than 0");
            }
            string breakText;
            AppControllerResources.IsDownOrPaused = true;

            for (int i = 0; i < sec; i++)
            {
                

                Thread.Sleep(1000);
                
            }
            AppControllerResources.IsDownOrPaused = false;

            breakText = $"The Application was paused for {sec} seconds";

            
            
            return Ok(breakText);
        }

        public IActionResult terminateapp()
        {
            string terminateText = "The Application is now terminated";
            AppControllerResources.IsDownOrPaused = true;


            return Ok(terminateText);
        }

        public async Task<IActionResult> healthapp()
        {
            if (AppControllerResources.IsDownOrPaused == false)
            {
                string healthy = "Healthy";
                return Ok(healthy);
            }
            else
            {
                string unhealthy = "Unhealthy";
                return BadRequest(unhealthy);
            }


            
        }
    }
}
