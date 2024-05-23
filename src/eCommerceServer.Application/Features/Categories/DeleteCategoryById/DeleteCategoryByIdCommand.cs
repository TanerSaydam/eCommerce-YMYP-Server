using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Categories.RemoveCategory;
public sealed record DeleteCategoryByIdCommand(
    Guid Id) : IRequest<Result<string>>;
