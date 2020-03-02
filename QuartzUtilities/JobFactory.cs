using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Quartz.Spi;

namespace QuartzUtilities
{
    public sealed class JobFactory : IJobFactory
    {
        private readonly IServiceProvider sp;

        public JobFactory(IServiceProvider sp)
        {
            this.sp = sp;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var job = sp.GetService(bundle.JobDetail.JobType) as IJob;
            return job;
        }

        public void ReturnJob(IJob job)
        {
            //Do something if need
        }
    }
}
