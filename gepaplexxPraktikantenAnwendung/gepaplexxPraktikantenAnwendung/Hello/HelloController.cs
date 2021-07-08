using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.Hello
{
    public class HelloController : Controller
    {
        public async Task<IActionResult> appAsync(int name)
        {

            Console.WriteLine("Success");
            string helloText;


            helloText = $"Hello: {name}.";

            return Ok(helloText);
        }
    }
}
