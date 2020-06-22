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
            _ = WarmUp();
        }

        private async Task WarmUp()
        {
            await this.WarmingUp();
            this.IsReady = true;
        }

        protected abstract Task WarmingUp();
    }
}
