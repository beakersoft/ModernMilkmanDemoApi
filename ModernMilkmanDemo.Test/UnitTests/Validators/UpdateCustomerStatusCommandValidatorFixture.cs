using AutoFixture;
using FluentValidation.TestHelper;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using ModernMilkmanDemoApi.Core.Handlers.Commands;
using ModernMilkmanDemoApi.Core.Validators;
using Moq;
using Xunit;

namespace ModernMilkmanDemo.Test.UnitTests.Validators
{
    public class UpdateCustomerStatusCommandValidatorFixture
    {
        private readonly Fixture _fixture;
        private readonly Mock<IRepository> _mockRepository;
        private readonly UpdateCustomerStatusCommandValidator _validator;

        public UpdateCustomerStatusCommandValidatorFixture()
        {
            _mockRepository = new Mock<IRepository>();
            _fixture = new Fixture();
            _validator = new UpdateCustomerStatusCommandValidator(_mockRepository.Object);
        }

        [Fact]
        public void Validate_Should_NotAllowWhenCustomerNotExist()
        {
            _mockRepository.Setup(x => x.GetByIdAsync<Customer>(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var result = _validator.TestValidate(new UpdateCustomerStatusCommand(1, false));

            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}