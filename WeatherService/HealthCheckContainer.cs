using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherService
{
    public sealed class HealthCheckContainer
    {
        private readonly Action warmUpAction;
        private readonly object syncRoot;
        private bool isWarmUpStarted;

        public bool IsValid { get; private set; }


        public HealthCheckContainer(Action warmUpAction)
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
                    throw new Exception("сервис уже валиден, неверное действие");

                Task.Run(WarmingUp);

                isWarmUpStarted = true;
            }
        }
    }
}
