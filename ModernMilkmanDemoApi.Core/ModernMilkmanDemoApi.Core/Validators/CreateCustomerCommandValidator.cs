using FluentValidation;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using ModernMilkmanDemoApi.Core.Handlers.Commands;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private IRepository _repository;

        public CreateCustomerCommandValidator(IRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.CustomerModel.EmailAddress).MustAsync(async (emailAddress, cancellation) =>
            {
                bool exists = await NotAlreadyExist(emailAddress);
                return !exists;
            }).WithMessage("Email Address already exists");

        }

        private async Task<bool> NotAlreadyExist(string emailAddress)
        {
            var existingUser = await _repository.
                                WhereAsync<Customer>(x => x.EmailAddress == emailAddress);

            return existingUser.Any();
        }



    }
}
