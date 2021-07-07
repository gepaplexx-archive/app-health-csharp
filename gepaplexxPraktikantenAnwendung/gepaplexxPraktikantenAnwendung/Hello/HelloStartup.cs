
using System.Threading.Tasks;
using Microsoft.Docs.Samples;
using System.Threading;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using gepaplexxPraktikantenAnwendung.Break;
using Microsoft.Extensions.Hosting;

namespace gepaplexxPraktikantenAnwendung.Hello
{
    public class HelloStartup : BackgroundService, IHostedService
    {
        private readonly HelloTaskKontex _superTaskContext;
        public HelloStartup(HelloTaskKontex helloTaskKontex)
        {
            _superTaskContext = helloTaskKontex;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(10_000, stoppingToken);

        }
    }
}

 
