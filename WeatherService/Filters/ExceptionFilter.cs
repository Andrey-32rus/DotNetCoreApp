using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ALogger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeatherService.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ALog logger;
        public ExceptionFilter(ALog logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            if (exception is AggregateException e)
            {
                logger.Error(e.ToString(), null);
            }
            else
            {
                logger.Error(exception.ToString(), null);
            }

            var res = new Contracts.SimpleContract {Field1 = "f1", Field2 = "f2"};
            context.Result = new ObjectResult(res) {StatusCode = (int) HttpStatusCode.InternalServerError};
            context.ExceptionHandled = true;
        }
    }
}
