﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModernMilkmanDemoApi.Core.Handlers.Commands;
using ModernMilkmanDemoApi.Core.Handlers.Queries;
using ModernMilkmanDemoApi.Core.Models;
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
        public async Task<IActionResult> UpdateCustomerActiveStatus(long id, bool isActive)
        {
            var command = new UpdateCustomerStatusCommand(id, isActive);
            await _mediator.Send(command);
            return Ok();
        }


        [HttpDelete]
        [Route("deletecustomeraddress/{customerId}/{addressId}")]
        public async Task<IActionResult> DeleteCustomerAddress(long customerId, long addressId)
        {
            var command = new DeleteCustomerAddressCommand(customerId, addressId);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete]
        [Route("deletecustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var command = new DeleteCustomerCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
