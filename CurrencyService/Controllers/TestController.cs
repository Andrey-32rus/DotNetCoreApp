using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceUtils.Filters;

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

        [MyAuthorization]
        [HttpGet("Auth")]
        public ActionResult Auth()
        {
            return Ok();
        }

        [HttpGet("StatusCode")]
        public ActionResult StatusCode()
        {
            return StatusCode(402);
        }
    }
}
