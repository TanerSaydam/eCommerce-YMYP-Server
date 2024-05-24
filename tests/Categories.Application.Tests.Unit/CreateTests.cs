using AutoMapper;
using eCommerceServer.Application.Behaviors;
using eCommerceServer.Application.Features.Categories.CreateCategory;
using eCommerceServer.Domain.Categories;
using FluentAssertions;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Linq.Expressions;
using TS.Result;

namespace Categories.Application.Tests.Unit;

public class CreateTests
{
    private readonly IMediator sut;
    private readonly ICategoryRepository categoryRepository = Substitute.For<ICategoryRepository>();
    private readonly IMapper mapper = Substitute.For<IMapper>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly IServiceProvider serviceProvider;
    public CreateTests()
    {
        var services = new ServiceCollection();

        services.AddTransient(_ => categoryRepository);
        services.AddTransient(_ => mapper);
        services.AddTransient(_ => unitOfWork);
        services.AddTransient<IRequestHandler<CreateCategoryCommand, Result<string>>, CreateCategoryCommandHandler>();

        services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateCategoryCommand>();
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        serviceProvider = services.BuildServiceProvider();
        sut = serviceProvider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Create_ShouldThrowException_WhenValidateFailure()
    {
        //Arrange
        var command = new CreateCategoryCommand("", null);

        //Act        
        Func<Task> act = async () => { await sut.Send(command); };

        //Assert        
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Create_ShouldIsSuccessfulReturnFalse_WhenNameAlreadyExists()
    {
        //Arrange
        var command = new CreateCategoryCommand("ExistingName", null);
        categoryRepository.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);

        //Act
        var result = await sut.Send(command, default);

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
        var result = await sut.Send(command, default);

        //Assert
        result.IsSuccessful.Should().Be(true);
        result.Data.Should().Be("Category create is successful");
    }
}