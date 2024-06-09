using eCommerceServer.Application;
using eCommerceServer.Application.Features.Companies.GetAllCompany;
using eCommerceServer.Domain.Companies;
using eCommerceServer.Domain.Shared;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace Companies.Application.Tests.Unit;
public class GetAllTests
{
    private readonly IMediator sut;
    private readonly ICompanyRepository companyRepository = Substitute.For<ICompanyRepository>();
    private readonly IServiceProvider serviceProvider;
    public GetAllTests()
    {
        var services = new ServiceCollection();

        services.AddTransient(_ => companyRepository);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        serviceProvider = services.BuildServiceProvider();
        sut = serviceProvider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task GetAll_ShouldReturnEmpty_WhenCompanyListEmpty()
    {
        //Arrange
        var request = new GetAllCompanyQuery();
        var listCompany = new List<Company>().AsQueryable().BuildMock();

        companyRepository.GetAll().Returns(listCompany);

        //Act
        var result = await sut.Send(request, default);

        //Assert
        result.Data!.Count.Should().Be(0);
    }

    [Fact]
    public async Task GetAll_ShouldReturnList_WhenCompanyHaveRecord()
    {
        //Arrange
        var request = new GetAllCompanyQuery();
        var CompanyList = new List<Company>()
        {
            new Company()
            {
                Name = new Name("Harun"),
                TaxDepartment = TaxDepartmentSmartEnum.Esenler,
                TaxNumber = new TaxNumber("66592471178"),
                Address = new Address("Türkiye","İstanbul", "Beykoz", "Yalıköy","Şahinler Apt")
            },
            new Company()
            {
                Name = new Name("Taner"),
                TaxDepartment = TaxDepartmentSmartEnum.Fatih,
                TaxNumber = new TaxNumber("81693705694"),
                Address = new Address("Türkiye","İstanbul", "Beykoz", "Yalıköy","Şahinler Apt")
            }
        }.AsQueryable().BuildMock();

        companyRepository.GetAll().Returns(CompanyList);

        //Act
        var result = await sut.Send(request, default);

        //Assert
        result.Data!.Count.Should().Be(2);
        result.Data!.Should().BeEquivalentTo(CompanyList);
    }
}
