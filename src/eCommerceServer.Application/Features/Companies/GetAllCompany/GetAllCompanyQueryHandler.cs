using eCommerceServer.Domain.Companies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.GetAllCompany;
internal sealed class GetAllCompanyQueryHandler(
    ICompanyRepository companyRepository) : IRequestHandler<GetAllCompanyQuery, Result<List<Company>>>
{
    public async Task<Result<List<Company>>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
    {
        var getCompanies = await companyRepository.GetAll().ToListAsync(cancellationToken);

        return Result<List<Company>>.Succeed(getCompanies);
    }
}
