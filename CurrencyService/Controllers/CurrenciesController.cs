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
        public List<CurrencyModel> Get()
        {
            return MongoDao.GetAllCurrencies();
        }

        [HttpGet("{id}")]
        public CurrencyModel Get(int id)
        {
            return MongoDao.GetCurrencyById(id);
        }
    }
}
