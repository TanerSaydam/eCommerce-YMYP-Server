using eCommerceServer.Application;
using eCommerceServer.Application.Features.Categories.GetAllCategory;
using eCommerceServer.Domain.Categories;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace Categories.Application.Tests.Unit;
public class GetAllTests
{
    private readonly IMediator sut;
    private readonly ICategoryRepository categoryRepository = Substitute.For<ICategoryRepository>();
    private readonly IServiceProvider serviceProvider;
    public GetAllTests()
    {
        var services = new ServiceCollection();

        services.AddTransient(_ => categoryRepository);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        serviceProvider = services.BuildServiceProvider();
        sut = serviceProvider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task GetAll_ShouldReturnEmpty_WhenCategoryListEmpty()
    {
        // Arrange
        var query = new GetAllCategoryQuery();
        var emptyCategoryList = new List<Category>().AsQueryable().BuildMock();

        categoryRepository
            .GetAll()
            .Returns(emptyCategoryList);

        // Act
        var result = await sut.Send(query, default);

        // Assert
        result.Data!.Count.Should().Be(0);
    }


    [Fact]
    public async Task GetAll_ShouldReturnList_WhenCategoryListHaveCategories()
    {
        // Arrange
        var query = new GetAllCategoryQuery();
        var emptyCategoryList = new List<Category>()
        {
            new Category()
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                MainCategoryId = null,
                Name = new("Elektronik")
            }
        }.AsQueryable().BuildMock();

        categoryRepository
            .GetAll()
            .Returns(emptyCategoryList);

        // Act
        var result = await sut.Send(query, default);

        // Assert
        result.Data!.Count.Should().Be(1);
    }

}
