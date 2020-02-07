using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherService
{
    public sealed class HealthCheckContainer
    {
        public bool IsValid { get; private set; }

        public HealthCheckContainer()
        {
            IsValid = false;
        }

        public void SetValid()
        {
            if(IsValid == true)
                throw new Exception("сервис уже валиден, неверное действие");

            IsValid = true;
        }
    }
}
