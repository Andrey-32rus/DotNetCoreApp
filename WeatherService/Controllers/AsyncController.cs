using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsyncController : ControllerBase
    {
        [HttpGet]
        public async Task<SimpleContract> Get()
        {
            using var http = new HttpClient();
            var message = await http.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
            var json = await message.Content.ReadAsStringAsync();
            return new SimpleContract
            {
                Field1 = json,
                Field2 = json
            };
        }
    }
}
