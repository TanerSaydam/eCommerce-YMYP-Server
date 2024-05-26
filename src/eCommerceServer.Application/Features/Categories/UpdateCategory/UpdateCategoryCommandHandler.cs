using AutoMapper;
using eCommerceServer.Domain.Categories;
using eCommerceServer.Domain.Shared;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Categories.UpdateCategory;
internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetByExpressionAsync(x => x.Id == request.Id, cancellationToken);
        if (category is null)
        {
            return Result<string>.Failure("Category not found");
        }

        if (category.Name.Value != request.Name)
        {
            var isNameExists = await categoryRepository.AnyAsync(y => y.Name == new Name(request.Name), cancellationToken);
            if (isNameExists)
            {
                return Result<string>.Failure("Name is already exists");
            }
        }

        if (request.MainCategoryId is not null && request.Id == request.MainCategoryId)
        {
            return Result<string>.Failure("Main category cannot be itself");
        }

        mapper.Map(request, category);
        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Category updated is successful");
    }
}
