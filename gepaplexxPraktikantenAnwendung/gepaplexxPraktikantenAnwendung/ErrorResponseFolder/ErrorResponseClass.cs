using gepaplexxPraktikantenAnwendung.Break;
using gepaplexxPraktikantenAnwendung.Hello;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.ErrorResponse
{
    public class ErrorResponseClass : PageModel
    {
        private readonly StartupTaskContext _contextBreak;
        private readonly HelloTaskKontex _contextHello;
        private readonly RequestDelegate _next;

        public ErrorResponseClass(StartupTaskContext context, HelloTaskKontex context1, RequestDelegate next)
        {
            _contextBreak = context;
            _contextHello = context1;
            _next = next;
           // Invoke(httpContextNew);
        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            if (_contextBreak.IsDown || _contextHello.IsHello)
            {
                await _next(httpContext);
            }
            else
            {
                var response = httpContext.Response;
                response.StatusCode = 503;
                response.Headers["Retry-After"] = "10";
                await response.WriteAsync("Service Unavailable");
                await response.WriteAsync("Bye Unkown");
                await Task.Delay(10_000);
                response.StatusCode = 200;
            }
        }
    }
}
