using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyLib;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CurrencyResponse>> Get()
        {
            try
            {
                return MongoDao.GetAllCurrencies().Select(x => new CurrencyResponse(x)).ToArray();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CurrencyResponse> Get(int id)
        {
            try
            {
                var mongo = MongoDao.GetCurrencyById(id);
                return new CurrencyResponse(mongo);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
