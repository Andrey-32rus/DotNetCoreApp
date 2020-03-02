using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ALogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzUtilities;
using QuartzWorker.Jobs;

namespace QuartzWorker
{
    public class QuartzSchedulerService
    {
        private IConfiguration cfg;
        private readonly IHostEnvironment env;
        private readonly ALog logger;
        private readonly IJobFactory jobFactory;
        private readonly QuartzConfiguration qaCfg;

        private IScheduler scheduler;

        public QuartzSchedulerService(IConfiguration cfg, IHostEnvironment env, ALog logger, IJobFactory jobFactory, IOptions<QuartzConfiguration> qaCfg)
        {
            this.cfg = cfg;
            this.env = env;
            this.logger = logger;
            this.jobFactory = jobFactory;
            this.qaCfg = qaCfg.Value;
        }

        public async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    {"quartz.serializer.type", "binary"},
                    {"quartz.threadPool.threadCount", qaCfg.ThreadsCount.ToString()},
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                scheduler = await factory.GetScheduler();
                scheduler.JobFactory = jobFactory;

                List<IJobDescription> jobsList = new List<IJobDescription>()
                {
                    new HelloWorldJobDescriptor(),
                };

                foreach (var jobDescription in jobsList)
                {
                    await scheduler.ScheduleJob(jobDescription.GetJob(), jobDescription.GetTrigger());
                }

                // and start it off
                await scheduler.Start();
                logger.Info($"Scheduler Started with {qaCfg.ThreadsCount} threads", "RunProgram");
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }

        public async Task ShutDown()
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
