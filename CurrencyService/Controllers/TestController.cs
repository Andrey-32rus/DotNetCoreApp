using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthLib;
using Microsoft.AspNetCore.Mvc;
using ServiceAuthLib;

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
        public ActionResult<UserInfoResponse> Auth()
        {
            return MyAuthorization.GetUserInfo(HttpContext);
        }

        [HttpGet("StatusCode")]
        public ActionResult StatusCode()
        {
            return StatusCode(402);
        }
    }
}
