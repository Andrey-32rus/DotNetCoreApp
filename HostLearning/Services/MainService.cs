using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace HostLearning.Services
{
    public class MainService : BackgroundService
    {
        private readonly IHostApplicationLifetime applicationLifetime;
        public MainService(IHostApplicationLifetime applicationLifetime)
        {
            this.applicationLifetime = applicationLifetime;
        }

        private async Task Main()
        {
            await Console.Out.WriteLineAsync("Hello World").ConfigureAwait(false);
            applicationLifetime.StopApplication();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Main();
            return Task.CompletedTask;
        }
    }
}
