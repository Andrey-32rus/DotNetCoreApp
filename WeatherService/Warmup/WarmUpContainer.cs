using System;
using System.Threading.Tasks;

namespace WeatherService.Warmup
{
    public sealed class WarmupContainer
    {
        private readonly Action warmUpAction;
        private readonly object syncRoot;
        private bool isWarmUpStarted;

        public bool IsReady { get; private set; }


        public WarmupContainer(Action warmUpAction)
        {
            IsReady = false;
            syncRoot = new object();
            isWarmUpStarted = false;

            this.warmUpAction = warmUpAction;
        }

        private void WarmingUp()
        {
            warmUpAction.Invoke();
            IsReady = true;
        }

        public void WarmUp()
        {
            lock (syncRoot)
            {
                if (isWarmUpStarted == true)
                    throw new Exception("прогрев уже был запущен");

                Task.Run(WarmingUp);

                isWarmUpStarted = true;
            }
        }
    }
}
