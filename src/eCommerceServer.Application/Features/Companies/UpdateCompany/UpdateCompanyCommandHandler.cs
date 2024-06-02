using AutoMapper;
using eCommerceServer.Domain.Companies;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.UpdateCompany;
internal sealed class UpdateCompanyCommandHandler(
    ICompanyRepository companyRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCompanyCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company? company = await companyRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (company is null)
        {
            return Result<string>.Failure("Company not found");
        }

        if (request.TaxNumber != company.TaxNumber.Value)
        {
            var isTaxNumberExists = await companyRepository.AnyAsync(p => p.TaxNumber == new TaxNumber(request.TaxNumber), cancellationToken);
            if (isTaxNumberExists)
            {
                return Result<string>.Failure("Tax number already exists");
            }
        }

        mapper.Map(request, company);
        unitOfWork.SaveChanges();

        return Result<string>.Succeed("Company successfully updated");
    }
}
