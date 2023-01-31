using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;

namespace ModernMilkmanDemoApi.Core.Handlers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly IRepository _repository;

        public GetCustomerByIdQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.WhereAsync<Customer>(x => x.Active);

            return res.FirstOrDefault();
        }
    }
}