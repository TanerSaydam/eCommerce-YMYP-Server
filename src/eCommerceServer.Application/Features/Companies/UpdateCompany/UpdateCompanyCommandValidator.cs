using eCommerceServer.Application.Utilities;
using FluentValidation;

namespace eCommerceServer.Application.Features.Companies.UpdateCompany;

public sealed class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(p => p.Name).MinimumLength(3);

        RuleFor(p => p.TaxDepartmentValue).TaxDepartmentValueMustBeValid();

        RuleFor(p => p.TaxNumber).TaxNumberMustBeValid();

        RuleFor(p => p.Country).NotEmpty().MinimumLength(3);
        RuleFor(p => p.City).NotEmpty().MinimumLength(3);
        RuleFor(p => p.Town).NotEmpty().MinimumLength(3);
        RuleFor(p => p.Street).NotEmpty().MinimumLength(3);
        RuleFor(p => p.FullAddress).NotEmpty().MinimumLength(3);
    }
}
