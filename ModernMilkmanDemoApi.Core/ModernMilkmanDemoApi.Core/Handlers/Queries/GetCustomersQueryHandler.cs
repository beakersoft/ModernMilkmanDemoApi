using MediatR;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Handlers.Queries
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private IRepository _repository;

        public GetCustomersQueryHandler(IRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.WhereAsync<Customer>(x => (request.OnlyActive) ? x.Active == true : true );

            return res;
        }
    }
}
