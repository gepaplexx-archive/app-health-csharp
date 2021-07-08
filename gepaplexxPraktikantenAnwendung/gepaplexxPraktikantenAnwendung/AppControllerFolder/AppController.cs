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
        

        
        
        
        public async Task<IActionResult> helloapp(string vorname)
        {
            if (AppControllerResources.IsDownOrPaused == false) {

                string helloText; 
                    
                helloText = "Hello: "+ vorname + ".";


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

            
            string breakText;
            AppControllerResources.IsDownOrPaused = true;

            for (int i = 0; i < sec; i++)
            {
                

                Thread.Sleep(1000);
                
            }
            AppControllerResources.IsDownOrPaused = false;

            breakText = $"The Application is paused for {sec} seconds";

            
            
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
