using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ALogger;
using Quartz;
using QuartzUtilities;

namespace QuartzWorker.Jobs
{
    public class HelloWorldJobDescriptor : IJobDescription
    {
        public IJobDetail GetJob()
        {
            return JobBuilder.Create<HelloWorldJob>()
                .Build();
        }

        public ITrigger GetTrigger()
        {
            return TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();
        }
    }

    [DisallowConcurrentExecution]
    public class HelloWorldJob : IJob
    {
        private readonly ALog logger;

        public HelloWorldJob(ALog logger)
        {
            this.logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() => logger.Info("Hello World !!!", "HelloWorldJob"));
        }
    }
}
