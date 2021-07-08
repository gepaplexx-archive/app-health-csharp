using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace gepaplexxPraktikantenAnwendung.Hello
{
    public static class HelloExtensions
    {
        private static readonly HelloTaskContext _helloContext = new HelloTaskContext();
        public static IServiceCollection AddHelloTasks(this IServiceCollection services)
        {
            // Don't add StartupTaskContext if we've already added it
            if (services.Any(x => x.ServiceType == typeof(HelloTaskContext)))
            {
                return services;
            }

            return services.AddSingleton(_helloContext);
        }

        public static IServiceCollection AddHelloTask<H>(this IServiceCollection services)
            where H : class, IHostedService
        {

            return services
                .AddHelloTasks() // in case AddStartupTasks() hasn't been called
                .AddHostedService<H>();
        }

    }
}
