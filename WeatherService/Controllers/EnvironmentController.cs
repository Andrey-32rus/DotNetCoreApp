using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public EnvironmentController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpGet]
        public string Get()
        {
            return env.EnvironmentName;
        }
    }
}