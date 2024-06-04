using eCommerceServer.Domain.Companies;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.DeleteCompanyById;
internal class DeleteCompanyByIdHandler(
    ICompanyRepository companyRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCompanyByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCompanyByIdCommand request, CancellationToken cancellationToken)
    {
        Company? company = await companyRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (company is null)
        {
            return Result<string>.Failure("Company not found");
        }

        company.IsDeleted = true;
        companyRepository.Update(company);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Company successfully deleted");
    }
}
