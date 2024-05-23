using AutoMapper;
using eCommerceServer.Application.Features.Categories.CreateCategory;
using eCommerceServer.Domain.Categories;
using FluentAssertions;
using GenericRepository;
using MediatR;
using NSubstitute;
using System.Linq.Expressions;

namespace Categories.Application.Tests.Unit;

public class CreateTests
{
    private readonly CreateCategoryCommandHandler sut;
    private readonly ICategoryRepository categoryRepository = Substitute.For<ICategoryRepository>();
    private readonly IMapper mapper = Substitute.For<IMapper>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    public CreateTests()
    {
        sut = new CreateCategoryCommandHandler(categoryRepository, mapper, unitOfWork);
    }

    [Fact]
    public async Task Create_ShouldIsSuccessfulReturnFalse_WhenNameAlreadyExists()
    {
        //Arrange
        var command = new CreateCategoryCommand("ExistingName", null);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(false);
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Category is already exists");
    }

    [Fact]
    public async Task Create_ShouldIsSuccessfullReturnTrue_WhenNameIsUnique()
    {

        //Arrange
        var command = new CreateCategoryCommand("ExistingName", null);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);

        //Act
        var result = await sut.Handle(command, default);

        //Assert
        result.IsSuccessful.Should().Be(true);
        result.Data.Should().Be("Category create is successful");
    }
}