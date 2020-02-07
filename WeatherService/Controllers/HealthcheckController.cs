using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeatherService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckContainer hc;

        public HealthCheckController(HealthCheckContainer hc)
        {
            this.hc = hc;
        }

        public ActionResult Get()
        {
            try
            {
                if (hc.IsValid == false)
                    return StatusCode(429, null);

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
