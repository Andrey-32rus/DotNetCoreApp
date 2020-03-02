using Quartz;

namespace QuartzUtilities
{
    public interface IJobDescription
    {
        IJobDetail GetJob();
        ITrigger GetTrigger();
    }
}