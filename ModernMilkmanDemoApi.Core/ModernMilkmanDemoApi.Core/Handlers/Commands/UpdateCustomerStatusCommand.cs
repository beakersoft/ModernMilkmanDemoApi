namespace ModernMilkmanDemoApi.Core.Handlers.Commands
{
    public class UpdateCustomerStatusCommand : MediatR.IRequest
    {
        public UpdateCustomerStatusCommand(long id, bool isActive)
        {
            Id = id;
            IsActive = isActive;
        }

        public long Id { get; }
        public bool IsActive { get; }
    }
}
