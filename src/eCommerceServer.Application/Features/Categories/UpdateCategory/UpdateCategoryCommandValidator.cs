using FluentValidation;

namespace eCommerceServer.Application.Features.Categories.UpdateCategory;
public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50);
    }
}

