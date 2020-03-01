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
        private IHostEnvironment env;
        private ALog logger;

        private IScheduler scheduler;

        public ProgramService(IConfiguration cfg, IHostEnvironment env, ALog logger)
        {
            this.cfg = cfg;
            this.env = env;
            this.logger = logger;
        }

        public void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");
            logger.Info($"Environment: {env.EnvironmentName}", "main");

            Console.WriteLine(env.ContentRootPath);

            RunProgram().GetAwaiter().GetResult();

            Console.WriteLine($"{Environment.NewLine}Нажмите любую кнопку, чтобы завершить");



            Console.ReadLine();
        }

        private async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

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
