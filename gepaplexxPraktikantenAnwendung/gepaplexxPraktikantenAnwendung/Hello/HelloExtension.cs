using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace gepaplexxPraktikantenAnwendung.Hello
{
    public static class HelloExtension
    {
        private static readonly HelloTaskKontex _helloContext = new HelloTaskKontex();
        public static IServiceCollection AddHelloTasks(this IServiceCollection services)
        {
            // Don't add StartupTaskContext if we've already added it
            if (services.Any(x => x.ServiceType == typeof(HelloTaskKontex)))
            {
                return services;
            }

            return services.AddSingleton(_helloContext);
        }

        public static IServiceCollection AddHelloTask<T>(this IServiceCollection services)
            where T : class, IHostedService
        {

            return services
                .AddHelloTasks() // in case AddStartupTasks() hasn't been called
                .AddHostedService<T>();
        }

    }
}
