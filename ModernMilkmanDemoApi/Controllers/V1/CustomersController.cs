using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernMilkmanDemo.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            //create some dummy customers
            //create the mediator pipeline 
            //create the get request, let it have an include all optional flag
            //return from the query, need to use the Tin, TOut of mediator


            return new string[] { "value1", "value2" };
        }
    }
}
