using eCommerceServer.Application.Features.Categories.RemoveCategory;
using eCommerceServer.Application.Features.Categories.UpdateCategory;
using eCommerceServer.Domain.Categories;
using FluentAssertions;
using GenericRepository;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Linq.Expressions;

namespace Categories.Application.Tests.Unit;
public class DeleteByIdTests
{
    private readonly DeleteCategoryByIdCommandHandler sut;
    private readonly ICategoryRepository categoryRepository = Substitute.For<ICategoryRepository>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly Guid guid = Guid.NewGuid();

    public DeleteByIdTests()
    {
        sut = new DeleteCategoryByIdCommandHandler(categoryRepository, unitOfWork);
    }

    [Fact]
    public async Task DeleteById_ReturnIsSuccessfulFalse_WhenCategoryNotFound()
    {
        //Arrange
        var command = new DeleteCategoryByIdCommand(guid);
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).ReturnsNull();

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(false);
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Category not found");
    }

    [Fact]
    public async Task DeleteById_ReturnIsSuccessfulTrue_WhenCategoryIsDeleted()
    {
        //Arrange
        var category = new Category { Id = guid, MainCategoryId = null, Name = new("Domates"), IsDeleted = false };
        var command = new DeleteCategoryByIdCommand(guid);
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(category);

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(true);
        result.Data.Should().Be("Category deleted is successful");
    }
}
