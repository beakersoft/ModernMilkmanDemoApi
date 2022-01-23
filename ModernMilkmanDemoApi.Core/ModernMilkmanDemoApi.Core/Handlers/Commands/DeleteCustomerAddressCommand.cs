using ModernMilkmanDemoApi.Core.Domain;
using System.Collections.Generic;

namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class DeleteCustomerAddressCommand : MediatR.IRequest<IEnumerable<Address>>
    {
        public DeleteCustomerAddressCommand(long customerId, long addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }

        public long CustomerId { get; }
        public long AddressId { get; }

    }
}
