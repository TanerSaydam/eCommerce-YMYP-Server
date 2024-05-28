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
    string Street,
    string FullAddress) : IRequest<Result<string>>;
