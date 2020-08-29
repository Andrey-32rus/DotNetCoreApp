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
        private readonly IHostEnvironment hostEnvironment;
        public MainService(IHostApplicationLifetime applicationLifetime, IHostEnvironment hostEnvironment)
        {
            this.applicationLifetime = applicationLifetime;
            this.hostEnvironment = hostEnvironment;
        }

        private async Task Main()
        {
            await Console.Out.WriteLineAsync($"Environment: {hostEnvironment.EnvironmentName}").ConfigureAwait(false);
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
