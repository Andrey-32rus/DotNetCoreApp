﻿using System.Web.Http;

namespace WebApiOwin.Controllers
{
    [MyAuthorization]
    public class ExampleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
