namespace ModernMilkmanDemo.Test.UnitTests.Handlers
{
    //public class DeleteCustomerAddressCommandHandlerFixture
    //{
    //    private readonly DeleteCustomerAddressCommandHandler _handler;
    //    private readonly Mock<IRepository> _mockRepository;
    //    private readonly Fixture _fixture;

    //    public DeleteCustomerAddressCommandHandlerFixture()
    //    {
    //        _fixture = new Fixture();
    //        _mockRepository = new Mock<IRepository>();
    //        _handler = new DeleteCustomerAddressCommandHandler(_mockRepository.Object);
    //    }

    //    [Fact]
    //    public async Task Handle_PrimaryAddressShouldDeleteAndMoveToOtherAddress()
    //    {
    //        var addresses = CreateDummyAddresses();

    //        var customer = _fixture.Build<Customer>()
    //            .With(x => x.Address, CreateDummyAddresses())
    //            .Create();

    //        _mockRepository.Setup(x => x.GetByIdAsync<Address>(It.IsAny<long>()))
    //            .ReturnsAsync(addresses.First(x => x.PrimaryAddress));

    //        _mockRepository.Setup(x => x.WhereAsync(It.IsAny<Expression<Func<Address, bool>>>()))
    //            .ReturnsAsync(addresses);

    //        _mockRepository.Setup(x => x.GetByIdAsync<Customer>(It.IsAny<long>()))
    //            .ReturnsAsync(new Customer());

    //        var res = await _handler.Handle(new DeleteCustomerAddressCommand(1, 1), new CancellationToken());

    //        Assert.NotNull(res);
    //        _mockRepository.Verify(x => x.Update(It.IsAny<Address>()), Times.Once);
    //        _mockRepository.Verify(x => x.Delete(It.IsAny<Address>()), Times.Once);
    //        _mockRepository.Verify(x => x.SaveAsync(), Times.Once);
    //    }

    //    private static List<Address> CreateDummyAddresses()
    //    {
    //        return new List<Address>
    //        {
    //            new Address { Id = 1, PrimaryAddress = true},
    //            new Address { Id = 2, PrimaryAddress = false}
    //        };
    //    }

    //}
}