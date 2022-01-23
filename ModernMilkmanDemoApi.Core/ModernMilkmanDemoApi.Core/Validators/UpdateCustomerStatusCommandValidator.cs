using FluentValidation;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using ModernMilkmanDemoApi.Core.Handlers.Commands;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Validators
{
    public class UpdateCustomerStatusCommandValidator : AbstractValidator<UpdateCustomerStatusCommand>
    {
        private IRepository _repository;

        public UpdateCustomerStatusCommandValidator(IRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
            {
                bool exists = await NotAlreadyPassedStatus(id);
                return exists;
            }).WithMessage($"Customer not found or is already on that active status");
        }

        private async Task<bool> NotAlreadyPassedStatus(long id)
        {
            var existingCustomer = await _repository
                                .GetByIdAsync<Customer>(id);

            if (existingCustomer == null)
                return false;

            return true;
        }
    }
}
