using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("method")]
        public ActionResult<string> Method(string str)
        {
            if (string.IsNullOrWhiteSpace(str) == false)
                return str;
            return Unauthorized();
        }

        [HttpGet("exception")]
        public ActionResult Exception()
        {
            throw new Exception("Exception!!!");
        }

        [HttpGet("Auth")]
        public ActionResult Auth()
        {
            return Ok();
        }
    }
}
