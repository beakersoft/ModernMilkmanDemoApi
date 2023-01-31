using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Domain;
using ModernMilkmanDemoApi.Core.Handlers.Queries;
using Moq;
using Xunit;

namespace ModernMilkmanDemo.Test.UnitTests.Handlers
{
    public class GetCustomerByIdQueryHandlerTest
    {
        private readonly GetCustomerByIdQueryHandler _handler;
        private readonly Mock<IRepository> _mockRepo = new();

        public GetCustomerByIdQueryHandlerTest()
        {
            _handler = new GetCustomerByIdQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ReturnsCorrectCustomer()
        {
            var expectedCustomerId = 9999;
            var query = new GetCustomerByIdQuery(expectedCustomerId);

            var customer1 = new Customer { Id = 1, Forename = "Testy" };
            var customer2 = new Customer { Id = 9999, Forename = "MrTest" };
            var customers = new List<Customer> { customer1, customer2 };

            _mockRepo.Setup(x => x.WhereAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
                .ReturnsAsync(customers);

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Id.Should().Be(expectedCustomerId);
        }
    }
}