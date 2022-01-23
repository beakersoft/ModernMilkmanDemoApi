using MediatR;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private IRepository _repository;

        public DeleteCustomerCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync<Customer>(request.Id);

            _repository.Delete(customer);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
