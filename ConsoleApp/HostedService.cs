using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    public class HostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("StartAsync");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("StopAsync");
        }
    }
}
