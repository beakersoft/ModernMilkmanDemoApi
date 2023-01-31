namespace ModernMilkmanDemo.Test.UnitTests.Validators
{
    //public class DeleteCustomerAddressCommandValidatorFixture
    //{
    //    private readonly DeleteCustomerAddressCommandValidator _validator;
    //    private readonly Mock<IRepository> _mockRepository;
    //    private readonly Fixture _fixture;

    //    public DeleteCustomerAddressCommandValidatorFixture()
    //    {
    //        _mockRepository = new Mock<IRepository>();
    //        _fixture = new Fixture();
    //        _validator = new DeleteCustomerAddressCommandValidator(_mockRepository.Object);
    //    }

    //    [Fact]
    //    public void Validate_Should_NotAllowWhenCustomerNotExist()
    //    {
    //        _mockRepository.Setup(x => x.GetByIdAsync<Customer>(It.IsAny<long>()))
    //            .ReturnsAsync(value: null);

    //        var result = _validator.TestValidate(new DeleteCustomerAddressCommand(1, 1));

    //        result.ShouldHaveValidationErrorFor(x => x.CustomerId);

    //    }

    //    [Fact]
    //    public void Validate_Should_NotAllowWhenLastAddress()
    //    {
    //        _mockRepository.Setup(x => x.GetByIdAsync<Customer>(It.IsAny<long>()))
    //            .ReturnsAsync(new Customer());

    //        var result = _validator.TestValidate(new DeleteCustomerAddressCommand(1, 1));

    //        result.ShouldHaveValidationErrorFor(x => x.CustomerId);
    //    }

    //    [Fact]
    //    public void Validate_Should_NotAllowWhenAddressIdIsMissingFromCustomer()
    //    {
    //        var customer = _fixture.Build<Customer>()
    //           .With(x => x.Address, CreateDummyAddresses())
    //           .Create();

    //        _mockRepository.Setup(x => x.GetByIdAsync<Customer>(It.IsAny<long>()))
    //            .ReturnsAsync(customer);

    //        var result = _validator.TestValidate(new DeleteCustomerAddressCommand(1, 2222));

    //        result.ShouldHaveValidationErrorFor(x => x.AddressId);
    //    }

    //    [Fact]
    //    public void Validate_Should_AllowWith2Address()
    //    {
    //        var customer = _fixture.Build<Customer>()
    //            .With(x => x.Address, CreateDummyAddresses())
    //            .Create();

    //        _mockRepository.Setup(x => x.GetByIdAsync<Customer>(It.IsAny<long>()))
    //            .ReturnsAsync(customer);

    //        var result = _validator.TestValidate(new DeleteCustomerAddressCommand(1, 1));

    //        result.ShouldNotHaveValidationErrorFor(x => x.CustomerId);
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