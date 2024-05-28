using AutoMapper;
using eCommerceServer.Domain.Companies;
using eCommerceServer.Domain.Shared;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.CreateCompany;
public sealed record CreateCompanyCommand(
    string Name,
    int TaxDepartmentValue,
    string TaxNumber,
    string Country,
    string City,
    string Town,
    string Street) : IRequest<Result<string>>;


internal sealed class CreateCompanyCommandHandler
    (
        ICompanyRepository companyRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ): IRequestHandler<CreateCompanyCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var isTaxNumberExists = await companyRepository.AnyAsync(p => p.TaxNumber == new TaxNumber(request.TaxNumber), cancellationToken);
        if (isTaxNumberExists)
        {
            return Result<string>.Failure("Bu vergi numarası | tc kimlik numarası daha önce kaydedilmiş");
        }

        var company = mapper.Map<Company>(request);

        await companyRepository.AddAsync(company, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Şirket kaydı başarı ile kaydedildi.";
    }
}
