using System.Collections.Generic;
using MediatR;
using ModernMilkmanDemoApi.Core.Domain;

namespace ModernMilkmanDemoApi.Core.Handlers.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public GetCustomersQuery(bool onlyActive)
        {
            OnlyActive = onlyActive;
        }

        public bool OnlyActive { get; }
    }
}