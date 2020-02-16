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
    public class ProgramService
    {
        private IConfiguration configuration;
        private IHostEnvironment host;
        private ALog logger;

        public ProgramService(IConfiguration cfg, IHostEnvironment host, ALog logger)
        {
            configuration = cfg;
            this.host = host;
            this.logger = logger;
        }

        public void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");
            logger.Info($"Environment: {host.EnvironmentName}", "main");

            Transaction tr = new Transaction();
            tr.PerformTransaction();

            for (int i = 0; i < 2; i++)
            {
                Task.Run(() =>
                {
                    Console.WriteLine(new DateTimeOffset(tr.LastTransaction).ToUnixTimeSeconds());
                });
            }

            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
