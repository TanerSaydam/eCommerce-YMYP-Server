using AutoMapper;
using eCommerceServer.Domain.Categories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Categories.CreateCategory;
internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryExists = await categoryRepository.AnyAsync(x => x.Name == new Name(request.Name), cancellationToken); 
        if (isCategoryExists)
        {
            return Result<string>.Failure("Category is already exists");
        }

        Category category = mapper.Map<Category>(request);

        await categoryRepository.AddAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Category create is successful");
    }
}
