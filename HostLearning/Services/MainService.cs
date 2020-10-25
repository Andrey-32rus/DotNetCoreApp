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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Console.Out.WriteLineAsync($"Environment: {hostEnvironment.EnvironmentName}");
            while (true)
            {
                await Console.Out.WriteLineAsync($"ping");
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}
