using eCommerceServer.Domain.Categories;
using MediatR;
using NSubstitute;

namespace Categories.Application.Tests.Unit;

public class CreateTests
{
    private readonly IMediator sut;
    private readonly ICategoryRepository categoryRepository = Substitute.For<ICategoryRepository>();
    public CreateTests()
    {
    }

    [Fact]
    public void Create_ShouldIsSuccessfulReturnFalse_WhenNameAlreadyExists()
    {
        //Arrange


        //Act


        //Assert


    }
}