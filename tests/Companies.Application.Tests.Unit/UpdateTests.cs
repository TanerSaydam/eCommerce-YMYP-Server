using AutoMapper;
using eCommerceServer.Application;
using eCommerceServer.Application.Behaviors;
using eCommerceServer.Application.Features.Companies.UpdateCompany;
using eCommerceServer.Domain.Companies;
using eCommerceServer.Domain.Shared;
using FluentAssertions;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Linq.Expressions;

namespace Companies.Application.Tests.Unit;
public class UpdateTests
{
    private readonly IMediator sut;
    private readonly ICompanyRepository companyRepository = Substitute.For<ICompanyRepository>();
    private readonly IMapper mapper = Substitute.For<IMapper>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly IServiceProvider serviceProvider;
    private UpdateCompanyCommand command;
    public Guid id;
    public UpdateTests()
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
        command = new UpdateCompanyCommand(
            id,
            "Taner Saydam LTD ŞTİ",
            1,
            "27129082540",
            "Türkiye",
            "Kayseri",
            "Kocasinan",
            "Merkez",
            "Kocasinan Kayseri Merkez");


    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenValidationFailed()
    {
        //Arrange
        command = new UpdateCompanyCommand(
            id,
            "Taner Saydam LTD ŞTİ",
            1,
            "11111111",
            "Türkiye",
            "Kayseri",
            "Kocasinan",
            "Merkez",
            "Kocasinan Kayseri Merkez");

        //Act
        var action = async () => await sut.Send(command, default);

        //Assert
        await action.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Update_ShouldReturnFalse_WhenCompanyNotFound()
    {
        //Arrange
        companyRepository.GetByExpressionWithTrackingAsync(Arg.Any<Expression<Func<Company, bool>>>()).ReturnsNull();

        //Act
        var result = await sut.Send(command, default);

        //Assert
        result.IsSuccessful.Should().BeFalse();
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Company not found");
    }

    [Fact]
    public async Task Update_ShouldReturnFalse_WhenTaxNumberExists()
    {
        //Arrange
        Company existingCompany = new Company()
        {
            Id = id,
            Name = new Name("Harun"),
            TaxDepartment = TaxDepartmentSmartEnum.FromValue(1),
            TaxNumber = new TaxNumber("35076411108"),
            Address = new Address("Türkiye", "İstanbul", "Beykoz", "Yalıköy", "Şahinler Apt")
        };

        companyRepository.GetByExpressionWithTrackingAsync(Arg.Any<Expression<Func<Company, bool>>>()).Returns(existingCompany);
        companyRepository.AnyAsync(Arg.Any<Expression<Func<Company, bool>>>()).Returns(true);

        //Act
        var result = await sut.Send(command, default);

        //Assert
        result.IsSuccessful.Should().BeFalse();
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Tax number already exists");

    }


    [Fact]
    public async Task Update_ShouldReturnsSuccessful_WhenCompanyExistsAndTaxNumberUnique()
    {
        //Arrange
        Company existingCompany = new Company()
        {
            Id = id,
            Name = new Name("Harun"),
            TaxDepartment = TaxDepartmentSmartEnum.FromValue(1),
            TaxNumber = new TaxNumber("35076411108"),
            Address = new Address("Türkiye", "İstanbul", "Beykoz", "Yalıköy", "Şahinler Apt")
        };
        companyRepository.GetByExpressionWithTrackingAsync(Arg.Any<Expression<Func<Company, bool>>>()).Returns(existingCompany);
        companyRepository.AnyAsync(Arg.Any<Expression<Func<Company, bool>>>()).Returns(false);

        //Act
        var result = await sut.Send(command, default);

        //Assert
        result.IsSuccessful.Should().BeTrue();
        result.Data.Should().Be("Company successfully updated");
    }

}
