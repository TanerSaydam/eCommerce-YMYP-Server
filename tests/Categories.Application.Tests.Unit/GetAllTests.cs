using AutoMapper;
using eCommerceServer.Application;
using eCommerceServer.Application.Features.Categories.GetAllCategory;
using eCommerceServer.Domain.Categories;
using FluentAssertions;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        //Arrange
        var query = new GetAllCategoryQuery();
        categoryRepository.GetAll().Include(x=> x.MainCategory).ToListAsync(default).Returns(new List<Category>());

        //Act
        var result = await sut.Send(query, default);

        //Assert
        result.Data!.Count().Should().Be(0);
    }

}
