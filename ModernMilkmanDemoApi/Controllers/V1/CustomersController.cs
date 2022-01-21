using Microsoft.AspNetCore.Mvc;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkmanDemo.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {
        private IRepository _repository;

        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            //create some dummy customers
            //create the mediator pipeline 
            //create the get request, let it have an include all optional flag
            //return from the query, need to use the Tin, TOut of mediator

            var luke = await _repository.WhereAsync<Customer>(x => true);
            return Ok(luke.ToList());
        }
    }
}
