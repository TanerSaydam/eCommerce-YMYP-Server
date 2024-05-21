using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    string Name,
    Guid? MainCategoryId) : IRequest<Result<string>>;