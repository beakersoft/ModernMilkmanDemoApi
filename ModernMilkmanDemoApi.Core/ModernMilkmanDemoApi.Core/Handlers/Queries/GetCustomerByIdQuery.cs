using MediatR;
using ModernMilkmanDemoApi.Core.Domain;

namespace ModernMilkmanDemoApi.Core.Handlers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }
    }
}