using MediatR;
using ModernMilkmanDemoApi.Core.Data;
using System;
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

        public Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
