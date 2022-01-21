using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModernMilkmanDemoApi.Core.Handlers.Commands;
using ModernMilkmanDemoApi.Core.Handlers.Queries;
using ModernMilkmanDemoApi.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkmanDemo.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(bool onlyActive = false)
        {
            var res = await _mediator.Send(new GetCustomersQuery(onlyActive));

            if (!res.Any())
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        [Route("createcustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel model)
        {
            var command = new CreateCustomerCommand(model);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("updatecustomeractivestatus/{id}/{isActive}")]
        public async Task<IActionResult> UpdateCustomerActiveStatus(int id, bool isActive)
        {


           return Ok();
        }


        [HttpDelete]
        [Route("deletecustomeraddress/{id}")]
        public async Task<IActionResult> DeleteCustomerAddress(int id)
        {
        
            return Ok();
        }

        [HttpDelete]
        [Route("deletecustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {

            return Ok();

        }
    }
}
