using MediatR;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class DeleteCustomerAddressCommandHandler : IRequestHandler<DeleteCustomerAddressCommand, IEnumerable<Address>>
    {
        private IRepository _repository;

        public DeleteCustomerAddressCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Address>> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync<Address>(request.AddressId);

            if (address.PrimaryAddress)
                await UpdateNewAddressToPrimary(request);

            _repository.Delete(address);
            await _repository.SaveAsync();

            var customer = await _repository.GetByIdAsync<Customer>(request.CustomerId);

            return customer.Address;
        }

        private async Task UpdateNewAddressToPrimary(DeleteCustomerAddressCommand request)
        {
            var customerAddresses = await _repository.WhereAsync<Address>(x => x.Customer.Id == request.CustomerId);
            var addressToUpdate = customerAddresses.First(x => !x.PrimaryAddress);
            addressToUpdate.PrimaryAddress = true;
            _repository.Update(addressToUpdate);
        }
    }
}
