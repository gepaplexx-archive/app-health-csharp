using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace gepaplexxPraktikantenAnwendung.Terminate
{
    public class TerminateStartup : BackgroundService, IHostedService
    {
        private readonly TerminateContext _terminateContext;
        public TerminateStartup(TerminateContext terminateContext)
        {
            _terminateContext = terminateContext;
        }

        // run the task
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(10_000, stoppingToken);

        }
        
    }
}
