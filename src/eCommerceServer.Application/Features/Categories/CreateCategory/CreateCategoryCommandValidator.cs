using FluentValidation;

namespace eCommerceServer.Application.Features.Categories.CreateCategory;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50);
    }
}
