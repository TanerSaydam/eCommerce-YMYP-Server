using AutoMapper;
using eCommerceServer.Application;
using eCommerceServer.Application.Behaviors;
using eCommerceServer.Application.Features.Companies.DeleteCompanyById;
using eCommerceServer.Domain.Companies;
using eCommerceServer.Domain.Shared;
using FluentAssertions;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Linq.Expressions;

namespace Companies.Application.Tests.Unit;
public class DeleteByIdTests
{
    private readonly IMediator sut;
    private readonly ICompanyRepository companyRepository = Substitute.For<ICompanyRepository>();
    private readonly IMapper mapper = Substitute.For<IMapper>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly IServiceProvider serviceProvider;
    private readonly Guid id;
    public DeleteByIdTests()
    {
        var services = new ServiceCollection();
        services.AddTransient(_ => companyRepository);
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
        id = Guid.NewGuid();

    }

    [Fact]
    public async Task DeleteById_ShouldSuccessfulReturnFalse_WhenCompanyNotFound()
    {
        //Act
        var result = await sut.Send(new DeleteCompanyByIdCommand(id), default);

        //Assert
        result.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteById_ShouldSuccessful_WhenCompanyExists()
    {
        //Arrange
        Company company = new Company()
        {
            Id = id,
            Name = new Name("Harun"),
            TaxDepartment = TaxDepartmentSmartEnum.FromValue(1),
            TaxNumber = new TaxNumber("35076411108"),
            Address = new Address("Türkiye", "İstanbul", "Beykoz", "Yalıköy", "Şahinler Apt")
        };
        companyRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<Company, bool>>>()).Returns(company);

        //Act
        var result = await sut.Send(new DeleteCompanyByIdCommand(id), default);

        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
