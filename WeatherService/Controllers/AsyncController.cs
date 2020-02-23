using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ALogger;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Fluent;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsyncController : ControllerBase
    {
        private string ok = "OK";
        private string loggerKey = "Async/Get";
        private readonly ALog logger;

        public AsyncController(ALog logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<SimpleContract> Get()
        {
            using var http = new HttpClient();
            var message = await http.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
            var json = await message.Content.ReadAsStringAsync();

            logger.Info(ok, loggerKey);

            return new SimpleContract
            {
                Field1 = ok,
                Field2 = ok
            };
        }
    }
}
