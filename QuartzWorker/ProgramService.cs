using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ALogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using QuartzWorker.Jobs;

namespace QuartzWorker
{
    public class ProgramService
    {
        private IConfiguration cfg;
        private readonly IHostEnvironment env;
        private readonly ALog logger;

        private IScheduler scheduler;
        private readonly int threadsCount = 20;

        public ProgramService(IConfiguration cfg, IHostEnvironment env, ALog logger)
        {
            this.cfg = cfg;
            this.env = env;
            this.logger = logger;
        }

        public void Main(string[] args)
        {
            logger.Info($"Environment: {env.EnvironmentName}", "main");
            logger.Info(env.ContentRootPath, "main");

            RunProgram().GetAwaiter().GetResult();

            Console.WriteLine($"{Environment.NewLine}Нажмите любую кнопку, чтобы завершить");
            Console.ReadLine();

            ShutDown().GetAwaiter().GetResult();
        }

        private async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    {"quartz.serializer.type", "binary"},
                    {"quartz.threadPool.threadCount", threadsCount.ToString()},
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();
                logger.Info($"Scheduler Started with {threadsCount} threads", "RunProgram");

                List<IJobDescription> jobsList = new List<IJobDescription>()
                {
                    new HelloWorldJobDescriptor(),
                };

                foreach (var jobDescription in jobsList)
                {
                    await scheduler.ScheduleJob(jobDescription.GetJob(), jobDescription.GetTrigger());
                }
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }

        private async Task ShutDown()
        {
            try
            {
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
    }
}
