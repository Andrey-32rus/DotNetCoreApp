using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;

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

        [DisallowConcurrentExecution]
        protected class HelloWorldJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                await Console.Out.WriteLineAsync("Hello World !!!");
            }
        }
    }
}
