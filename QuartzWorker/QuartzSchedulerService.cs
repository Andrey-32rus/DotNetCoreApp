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
        //private IConfiguration cfg;
        //private readonly IHostEnvironment env;
        private readonly ALog logger;
        private readonly IJobFactory jobFactory;
        private readonly IOptions<QuartzConfiguration> qaCfg;

        private IScheduler scheduler;

        private int SchedulerThreadsCount => qaCfg.Value.ThreadsCount;

        public QuartzSchedulerService(ALog logger, IJobFactory jobFactory, IOptions<QuartzConfiguration> qaCfg)
        {
            //this.cfg = cfg;
            //this.env = env;
            this.logger = logger;
            this.jobFactory = jobFactory;
            this.qaCfg = qaCfg;
        }

        public async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    {"quartz.serializer.type", "binary"},
                    {"quartz.threadPool.threadCount", SchedulerThreadsCount.ToString()},
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
                logger.Info($"Scheduler Started with {SchedulerThreadsCount} threads", "RunProgram");
            }
            catch (SchedulerException se)
            {
                logger.Error(se.ToString(), "RunProgram");
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
                logger.Error(se.ToString(), "RunProgram");
            }
        }
    }
}
