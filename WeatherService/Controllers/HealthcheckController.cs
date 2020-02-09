using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherService.Warmup;

namespace WeatherService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly WarmupContainer hc;

        public HealthCheckController(WarmupContainer hc)
        {
            this.hc = hc;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                if (hc.IsReady == false)
                    return StatusCode(429, null);

                return Ok();
            }
            catch
            {
                return StatusCode(500, null);
            }
        }
    }
}
