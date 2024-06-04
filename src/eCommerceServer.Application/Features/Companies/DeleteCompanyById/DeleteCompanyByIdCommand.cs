using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.DeleteCompanyById;
public sealed record DeleteCompanyByIdCommand(
    Guid Id) : IRequest<Result<string>>;
