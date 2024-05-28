using AutoMapper;
using eCommerceServer.Application;
using eCommerceServer.Application.Behaviors;
using eCommerceServer.Application.Features.Companies.CreateCompany;
using eCommerceServer.Domain.Companies;
using FluentAssertions;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Linq.Expressions;

namespace Companies.Application.Tests.Unit;
public class CreateTests
{
    private readonly IMediator sut;
    private readonly ICompanyRepository companyRepository = Substitute.For<ICompanyRepository>();
    private readonly IMapper mapper = Substitute.For<IMapper>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly IServiceProvider serviceProvider;
    private CreateCompanyCommand command;
    public CreateTests()
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

        command = new CreateCompanyCommand(
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
    public async Task Create_ShouldThrowException_WhenValidateFailure()
    {
        //Arrange
        command = new CreateCompanyCommand(
            "Taner Saydam LTD ŞTİ",
            1,
            "2712908254",//geçersiz Vergi Numarası
            "Türkiye",
            "Kayseri",
            "Kocasinan",
            "Merkez",
            "Kocasinan Kayseri Merkez");

        //Act        
        Func<Task> act = async () => { await sut.Send(command); };

        //Assert        
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Create_ShouldIsSuccessfulReturnFalse_WhenTaxNumberAlreadyExists()
    {
        //Arrange        
        companyRepository.AnyAsync(Arg.Any<Expression<Func<Company, bool>>>()).Returns(true);

        //Act
        var result = await sut.Send(command, default);

        //Assert
        result.IsSuccessful.Should().Be(false);
        result.ErrorMessages.Should().HaveCount(1);
        result.ErrorMessages!.First().Should().Be("Tax number already exists");
    }


    [Fact]
    public async Task Create_ShouldIsSuccessfullReturnTrue_WhenTaxNumberIsUnique()
    {

        //Arrange        
        companyRepository.AnyAsync(Arg.Any<Expression<Func<Company, bool>>>()).Returns(false);

        //Act
        var result = await sut.Send(command, default);

        //Assert
        result.IsSuccessful.Should().Be(true);
        result.Data.Should().Be("Create company is successful");
    }
}
