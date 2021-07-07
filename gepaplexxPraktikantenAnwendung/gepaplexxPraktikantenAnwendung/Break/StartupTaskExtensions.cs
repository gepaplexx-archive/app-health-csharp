using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.Break
{
    public static class StartupTaskExtensions
    {
        private static readonly StartupTaskContext _sharedContext = new StartupTaskContext();
        public static IServiceCollection AddStartupTasks(this IServiceCollection services)
        {
            // Don't add StartupTaskContext if we've already added it
            if (services.Any(x => x.ServiceType == typeof(StartupTaskContext)))
            {
                return services;
            }

            return services.AddSingleton(_sharedContext);
        }

        public static IServiceCollection AddStartupTask<T>(this IServiceCollection services)
            where T : class, IHostedService
        {
            
            return services
                .AddStartupTasks() // in case AddStartupTasks() hasn't been called
                .AddHostedService<T>();
        }
    }
}
