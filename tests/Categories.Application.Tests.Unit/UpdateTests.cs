using AutoMapper;
using eCommerceServer.Application;
using eCommerceServer.Application.Behaviors;
using eCommerceServer.Application.Features.Categories.UpdateCategory;
using eCommerceServer.Domain.Categories;
using eCommerceServer.Domain.Shared;
using FluentAssertions;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Linq.Expressions;

namespace Categories.Application.Tests.Unit;
public class UpdateTests
{
    private readonly IMediator sut;
    private readonly ICategoryRepository categoryRepository = Substitute.For<ICategoryRepository>();
    private readonly IMapper mapper = Substitute.For<IMapper>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly IServiceProvider serviceProvider;
    public UpdateTests()
    {
        var services = new ServiceCollection();

        services.AddTransient(_ => categoryRepository);
        services.AddTransient(_ => mapper);
        services.AddTransient(_ => unitOfWork);

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        serviceProvider = services.BuildServiceProvider();
        sut = serviceProvider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Create_ShouldThrowException_WhenValidateFailure()
    {
        //Arrange
        var command = new UpdateCategoryCommand(Guid.NewGuid(), "", null);

        //Act        
        Func<Task> act = async () => { await sut.Send(command); };

        //Assert        
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Update_ReturnIsSuccessfulFalse_WhenCategoryNotFound()
    {
        //Arrange
        var command = new UpdateCategoryCommand(Guid.NewGuid(), "Elektronik", null);
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).ReturnsNull();

        //Act
        var result = await sut.Send(command, default);

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
        var command = new UpdateCategoryCommand(guid, "Elektronik", null);
        var existingCategory = new Category { Id = guid, Name = new Name("Existing Category") };
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(existingCategory);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);

        //Act
        var result = await sut.Send(command, default);

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
        var command = new UpdateCategoryCommand(guid, "Elektronik", guid);
        var existingCategory = new Category { Id = guid, Name = new Name("Existing Category") };
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(existingCategory);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);

        //Act
        var result = await sut.Send(command, default);

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
        var command = new UpdateCategoryCommand(guid, "Elektronik", null);
        var existingCategory = new Category { Id = guid, Name = new Name("Existing Category") };
        categoryRepository.GetByExpressionAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(existingCategory);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);

        //Act
        var result = await sut.Send(command, default);

        //Assert
        result.IsSuccessful.Should().Be(true);
        result.Data.Should().Be("Category updated is successful");
    }
}
