using eCommerceServer.Domain.Categories;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Categories.GetAllCategory;
public sealed record GetAllCategoryQuery() : IRequest<Result<List<Category>>>;