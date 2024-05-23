using AutoMapper;
using eCommerceServer.Application.Features.Categories.CreateCategory;
using eCommerceServer.Application.Features.Categories.UpdateCategory;
using eCommerceServer.Domain.Categories;
using FluentAssertions;
using GenericRepository;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Linq.Expressions;

namespace Categories.Application.Tests.Unit;
public class UpdateTests
{

    private readonly UpdateCategoryHandler sut;
    private readonly ICategoryRepository categoryRepository = Substitute.For<ICategoryRepository>();
    private readonly IMapper mapper = Substitute.For<IMapper>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();

    public UpdateTests()    {

        sut = new UpdateCategoryHandler(categoryRepository, mapper, unitOfWork);
    }

    [Fact]
    public async Task Update_ReturnIsSuccessfulFalse_WhenCategoryNotFound()
    {
        //Arrange
        var command = new UpdateCategoryCommand(Guid.NewGuid(), "New Category", null);
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).ReturnsNull();

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(false);
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Category not found");
    }

    [Fact]
    public async Task Update_ShouldIsSuccessfulReturnFalse_WhenNameAlreadyExists()
    {
        //Arrange
        var guid = Guid.NewGuid();
        var command = new UpdateCategoryCommand(guid, "New Category", null);
        var existingCategory = new Category { Id = guid, Name = new Name("Existing Category") };
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(existingCategory);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(false);
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Name is already exists");
    }


    [Fact]
    public async Task Update_ShouldIsSuccessfulReturnFalse_WhenMainCategoryIdEqualsId()
    {
        //Arrange
        var guid = Guid.NewGuid();
        var command = new UpdateCategoryCommand(guid, "New Category", guid);
        var existingCategory = new Category { Id = guid, Name = new Name("Existing Category") };
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(existingCategory);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(false);
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Main category cannot be itself");
    }

    [Fact]
    public async Task Update_ShouldBeUpdateCategory_WhenNameDoesNotExistsAndMainCategoryIdDoesNotEqualsId()
    {
        //Arrange
        var guid = Guid.NewGuid();
        var command = new UpdateCategoryCommand(guid, "New Category", null);
        var existingCategory = new Category { Id = guid, Name = new Name("Existing Category") };
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(existingCategory);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(true);
        result.Data.Should().Be("Category updated is successful");
    }
}
