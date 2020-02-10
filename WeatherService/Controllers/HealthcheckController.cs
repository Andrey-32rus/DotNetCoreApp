using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALogger;
using Microsoft.AspNetCore.Mvc;
using WeatherService.Warmup;

namespace WeatherService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly WarmupContainer hc;
        private ALog logger;

        public HealthCheckController(WarmupContainer hc, ALog logger)
        {
            this.hc = hc;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                if (hc.IsReady == false)
                    return StatusCode(429, null);

                logger.Info("Healthcheck 200", "HealthCheckController");
                return Ok();
            }
            catch
            {
                return StatusCode(500, null);
            }
        }
    }
}
