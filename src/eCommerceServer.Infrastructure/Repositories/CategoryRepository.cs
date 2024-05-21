using eCommerceServer.Domain.Categories;
using eCommerceServer.Infrastructure.Context;
using GenericRepository;

namespace eCommerceServer.Infrastructure.Repositories;
internal sealed class CategoryRepository : Repository<Category, ApplicationDbContext>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
