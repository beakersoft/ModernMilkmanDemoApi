using MediatR;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class UpdateCustomerStatusCommandHandler : IRequestHandler<UpdateCustomerStatusCommand>
    {
        private IRepository _repository;

        public UpdateCustomerStatusCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateCustomerStatusCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync<Customer>(request.Id);
            customer.Active = request.IsActive;

            _repository.Update(customer);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
