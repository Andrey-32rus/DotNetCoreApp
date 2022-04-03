using System.Web.Http;

namespace WebApiOwin.Controllers
{
    public class ExampleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
