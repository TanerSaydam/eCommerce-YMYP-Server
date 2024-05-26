using eCommerceServer.Domain.Companies;
using eCommerceServer.Infrastructure.Context;
using GenericRepository;

namespace eCommerceServer.Infrastructure.Repositories;
internal sealed class CompanyRepository : Repository<Company, ApplicationDbContext>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext context) : base(context)
    {
    }
}
