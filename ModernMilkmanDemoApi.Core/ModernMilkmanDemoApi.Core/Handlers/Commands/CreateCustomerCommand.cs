using ModernMilkmanDemoApi.Core.Models;

namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class CreateCustomerCommand : MediatR.IRequest
    {
        public CreateCustomerCommand(CustomerModel customerModel)
        {
            CustomerModel = customerModel;
        }

        public CustomerModel CustomerModel { get; }
    }
}
