using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyLib;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyService.Controllers
{
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        [HttpGet]
        public List<CurrencyModel> Get()
        {
            return MongoDao.GetAllCurrencies();
        }
    }
}
