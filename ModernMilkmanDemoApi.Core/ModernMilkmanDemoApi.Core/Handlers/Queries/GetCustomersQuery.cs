using ModernMilkmanDemoApi.Core.Domain;
using System.Collections.Generic;

namespace ModernMilkmanDemoApi.Core.Handlers.Queries
{
    public class GetCustomersQuery : MediatR.IRequest<IEnumerable<Customer>>
    {
        public GetCustomersQuery(bool onlyActive)
        {
            OnlyActive = onlyActive;
        }

        public bool OnlyActive { get; }
    }
}
