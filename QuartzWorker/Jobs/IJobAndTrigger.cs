using Quartz;

namespace QuartzWorker.Jobs
{
    public interface IJobDescription
    {
        IJobDetail GetJob();
        ITrigger GetTrigger();
    }
}