using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.Break
{
    public class BreakStartupTask : BackgroundService, IHostedService
    {
        private readonly StartupTaskContext _startupTaskContext;
        public BreakStartupTask(StartupTaskContext startupTaskContext)
        {
            _startupTaskContext = startupTaskContext;
        }

        // run the task
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(10_000, stoppingToken);
            
        }
    }


}
