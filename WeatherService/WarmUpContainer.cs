using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherService
{
    public sealed class WarmUpContainer
    {
        private readonly Action warmUpAction;
        private readonly object syncRoot;
        private bool isWarmUpStarted;

        public bool IsValid { get; private set; }


        public WarmUpContainer(Action warmUpAction)
        {
            IsValid = false;
            syncRoot = new object();
            isWarmUpStarted = false;

            this.warmUpAction = warmUpAction;
        }

        private void WarmingUp()
        {
            warmUpAction.Invoke();
            IsValid = true;
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
