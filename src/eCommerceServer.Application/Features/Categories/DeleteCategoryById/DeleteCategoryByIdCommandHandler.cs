using eCommerceServer.Domain.Categories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Categories.RemoveCategory;
internal sealed class DeleteCategoryByIdCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByExpressionAsync(x => x.Id == request.Id, cancellationToken);
        if (category is null)
        {
            return Result<string>.Failure("Category not found");
        }

        category.IsDeleted = true;
        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Category deleted is successful");
    }
}
