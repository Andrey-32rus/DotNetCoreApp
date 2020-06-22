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
        private readonly IWarmup wu;
        private ALog logger;

        public HealthCheckController(IWarmup wu, ALog logger)
        {
            this.wu = wu;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                if (wu.IsReady == false)
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
