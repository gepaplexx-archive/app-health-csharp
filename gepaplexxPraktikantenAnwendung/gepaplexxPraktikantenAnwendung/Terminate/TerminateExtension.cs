using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.Terminate
{
    public static class TerminateExtension
    {
        private static readonly TerminateContext _sharedContext = new TerminateContext();
        public static IServiceCollection AddTerminateTasks(this IServiceCollection services)
        {
            // Don't add StartupTaskContext if we've already added it
            if (services.Any(x => x.ServiceType == typeof(TerminateContext)))
            {
                return services;
            }

            return services.AddSingleton(_sharedContext);
        }

        public static IServiceCollection AddTerminateTask<T>(this IServiceCollection services)
            where T : class, IHostedService
        {

            return services
                .AddTerminateTasks() // in case AddStartupTasks() hasn't been called
                .AddHostedService<T>();
        }
    }
}
