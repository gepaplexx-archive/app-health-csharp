using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.Break
{
    public class BreakController : Controller
    {
        public async Task<IActionResult> appAsync(int sec)
        {

            Console.WriteLine("Success");
            string breakText;


            

            breakText = $"The Application is paused for {sec} seconds";

            return Ok(breakText);
        }
    }
}
