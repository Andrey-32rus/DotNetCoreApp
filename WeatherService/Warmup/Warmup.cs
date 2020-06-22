using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherService.Warmup
{
    public class Warmup : WarmupBase
    {
        protected override Task WarmingUp()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }
    }
}
