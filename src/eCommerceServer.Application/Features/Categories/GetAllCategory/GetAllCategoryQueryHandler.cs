using eCommerceServer.Domain.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eCommerceServer.Application.Features.Categories.GetAllCategory;
internal sealed class GetAllCategoryQueryHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoryQuery, Result<List<Category>>>
{
    public async Task<Result<List<Category>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = 
            await categoryRepository
            .GetAll()
            .Include(x=> x.MainCategory)
            .ToListAsync(cancellationToken);

        return Result<List<Category>>.Succeed(categories);
    }
}
