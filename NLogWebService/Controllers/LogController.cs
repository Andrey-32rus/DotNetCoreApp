using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Fluent;

namespace NLogWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public void Get()
        {
            logger.Info()
                .Message("log")
                .Property("propInt", 1)
                .Write();
        }
    }
}
