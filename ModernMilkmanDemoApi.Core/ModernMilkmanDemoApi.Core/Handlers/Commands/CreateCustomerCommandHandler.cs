﻿using MediatR;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private IRepository _repository;

        public CreateCustomerCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.FromModel(request.CustomerModel);

            await _repository.CreateAsync(customer);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
