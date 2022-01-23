using AutoFixture;
using FluentValidation.TestHelper;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using ModernMilkmanDemoApi.Core.Models;
using ModernMilkmanDemoApi.Core.Validators;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ModernMilkmanDemo.Test.UnitTests.Validators
{
    public class CreateCustomerCommandValidatorFixture
    {
        private readonly CreateCustomerCommandValidator _validator;
        private readonly Mock<IRepository> _mockRepository;
        private readonly Fixture _fixture;

        public CreateCustomerCommandValidatorFixture()
        {
            _mockRepository = new Mock<IRepository>();
            _fixture = new Fixture();
            _validator = new CreateCustomerCommandValidator(_mockRepository.Object);
        }

        [Fact]
        public void Validate_Should_NotAllowDuplicateEmailAddress()
        {
            var email = "test1@domain.com";
            var model = _fixture.Build<CustomerModel>()
                .With(x => x.EmailAddress, email)
                .Create();

            _mockRepository.Setup(x => x.WhereAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
                .ReturnsAsync(new List<Customer> { new Customer { EmailAddress = email } });

            var result = _validator.TestValidate(new ModernMilkmanDemoApi.Core.Handlers.Commands.CreateCustomerCommand(model));

            result.ShouldHaveValidationErrorFor(x => x.CustomerModel.EmailAddress);

        }

    }
}
