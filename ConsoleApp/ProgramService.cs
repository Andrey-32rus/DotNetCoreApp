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
        private IHostEnvironment env;
        private ALog logger;

        public ProgramService(IConfiguration cfg, IHostEnvironment env, ALog logger)
        {
            configuration = cfg;
            this.env = env;
            this.logger = logger;
        }

        public void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");
            logger.Info($"Environment: {env.EnvironmentName}", "main");

            Console.WriteLine(env.ContentRootPath);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.ReadLine();
        }
    }
}
