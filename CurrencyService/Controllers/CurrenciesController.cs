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
        public IEnumerable<CurrencyResponse> Get()
        {
            try
            {
                return MongoDao.GetAllCurrencies().Select(x => new CurrencyResponse(x));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public CurrencyResponse Get(int id)
        {
            try
            {
                var mongo = MongoDao.GetCurrencyById(id);
                return new CurrencyResponse(mongo);
            }
            catch (Exception e)
            {
                return null;
            }
           
        }
    }
}
