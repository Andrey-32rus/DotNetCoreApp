using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeadlockController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var service = new SomeService();
            service.DoSomeJobAsync().Wait();

            return Ok();
        }
    }

    public class SomeService
    {
        public async Task DoSomeJobAsync()
        {
            await Task.Delay(200);
            Thread.Sleep(100);
        }
    }
}
