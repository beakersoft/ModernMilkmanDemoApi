using FluentValidation;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using ModernMilkmanDemoApi.Core.Handlers.Commands;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Validators
{
    public class DeleteCustomerAddressCommandValidator : AbstractValidator<DeleteCustomerAddressCommand>
    {
        private IRepository _repository;

        public DeleteCustomerAddressCommandValidator(IRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.CustomerId).MustAsync(async (id, cancellation) =>
            {
                bool exists = await CustomerExists(id);
                return exists;
            }).WithMessage($"Customer not found");

            RuleFor(x => x.AddressId).MustAsync(async (model, id, cancellation) =>
            {
                bool exists = await AddressExistsOnCustomer(id, model.CustomerId);
                return exists;
            }).WithMessage($"Address id not present on customer");

            RuleFor(x => x.CustomerId).MustAsync(async (id, cancellation) =>
            {
                bool exists = await NotLastAddress(id);
                return exists;
            }).WithMessage($"Customer only has one address so address cannot be removed");
        }

        private async Task<bool> NotLastAddress(long customerId)
        {
            var existingCustomer = await _repository
                               .GetByIdAsync<Customer>(customerId);

            if (existingCustomer == null)
                return false;

            if (existingCustomer.Address.Count <= 1)
                return false;

            return true;
        }

        private async Task<bool> CustomerExists(long id)
        {
            var existingCustomer = await _repository
                                .GetByIdAsync<Customer>(id);

            if (existingCustomer == null)
                return false;

            return true;
        }

        private async Task<bool> AddressExistsOnCustomer(long addressId, long customerId)
        {
            var existingCustomer = await _repository
                                .GetByIdAsync<Customer>(customerId);

            if (existingCustomer == null)
                return false;

            if (!existingCustomer.Address.Any(x => x.Id == addressId))
                return false;

            return true;
        }
    }
}
