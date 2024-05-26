using FluentValidation;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.CreateCompany;
public sealed record CreateCompanyCommand(
    string Name,
    int TaxDepartmentValue,
    string TaxNumber,
    string Country,
    string City,
    string Town,
    string Street) : IRequest<Result<string>>;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(p => p.Name)
            .MinimumLength(3);
        
        //RuleFor(p )

        RuleFor(p => p.TaxNumber)
            .MinimumLength(10);

        RuleFor(p => p.Country)
            .MinimumLength(3);

        RuleFor(p => p.City)
            .MinimumLength(3);

        RuleFor(p => p.Town)
            .MinimumLength(3);
    }
}
