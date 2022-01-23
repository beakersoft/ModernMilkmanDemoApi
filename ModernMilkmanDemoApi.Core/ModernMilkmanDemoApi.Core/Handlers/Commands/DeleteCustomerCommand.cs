namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class DeleteCustomerCommand : MediatR.IRequest
    {
        public DeleteCustomerCommand(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
