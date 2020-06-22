using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.Warmup
{
    public abstract class WarmupBase : IWarmup
    {
        public bool IsReady { get; private set; }

        protected WarmupBase()
        {
            this.IsReady = false;
            Task.Run(WarmUp);
        }

        private void WarmUp()
        {
            this.WarmingUp();
            this.IsReady = true;
        }

        protected abstract void WarmingUp();
    }
}
