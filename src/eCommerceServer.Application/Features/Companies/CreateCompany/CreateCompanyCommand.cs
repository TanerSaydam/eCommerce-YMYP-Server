using eCommerceServer.Application.Utilities;
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

        RuleFor(p => p.TaxDepartmentValue)
            .TaxDepartmentValueMustBeValid();

        RuleFor(p => p.TaxNumber)
            .TaxNumberMustBeValid();

        RuleFor(p => p.Country)
            .MinimumLength(3);

        RuleFor(p => p.City)
            .MinimumLength(3);

        RuleFor(p => p.Town)
            .MinimumLength(3);


    }
}


internal sealed class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Result<string>>
{
    public Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
