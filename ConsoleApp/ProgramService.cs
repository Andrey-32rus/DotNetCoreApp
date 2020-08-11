using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ALogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    public class ProgramService : BackgroundService
    {
        private IConfiguration cfg;
        private IHostEnvironment env;
        private ALog logger;

        public ProgramService(IConfiguration cfg, IHostEnvironment env, ALog logger)
        {
            this.cfg = cfg;
            this.env = env;
            this.logger = logger;
        }

        public void Main()
        {
            logger.Info($"Environment: {env.EnvironmentName}", "main");
            logger.Info($"ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}", "main");
            logger.Info($"{ThreadPool.ThreadCount}", "main");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(() => Main(), stoppingToken);
            logger.Info($"ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}", "main");
            return Task.CompletedTask;
        }
    }
}
