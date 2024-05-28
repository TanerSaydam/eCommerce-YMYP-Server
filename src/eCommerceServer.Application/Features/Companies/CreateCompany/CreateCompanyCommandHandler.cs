using AutoMapper;
using eCommerceServer.Domain.Companies;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.CreateCompany;

internal sealed class CreateCompanyCommandHandler
    (
        ICompanyRepository companyRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateCompanyCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var isTaxNumberExists = await companyRepository.AnyAsync(p => p.TaxNumber == new TaxNumber(request.TaxNumber), cancellationToken);
        if (isTaxNumberExists)
        {
            return Result<string>.Failure("Tax number already exists");
        }

        var company = mapper.Map<Company>(request);

        await companyRepository.AddAsync(company, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Create company is successful";
    }
}
