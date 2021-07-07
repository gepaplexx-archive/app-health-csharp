using gepaplexxPraktikantenAnwendung.Break;
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
        private readonly StartupTaskContext _context;
        private readonly RequestDelegate _next;

        public ErrorResponseClass(StartupTaskContext context, RequestDelegate next)
        {
            _context = context;
            _next = next;
           // Invoke(httpContextNew);
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (_context.IsDown)
            {
                await _next(httpContext);
            }
            else
            {
                var response = httpContext.Response;
                response.StatusCode = 503;
                response.Headers["Retry-After"] = "30";
                await response.WriteAsync("Service Unavailable");
                await Task.Delay(10_000);
                response.StatusCode = 200;
            }
        }
    }
}
