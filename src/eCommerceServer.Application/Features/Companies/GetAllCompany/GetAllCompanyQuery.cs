using eCommerceServer.Domain.Companies;
using MediatR;
using TS.Result;

namespace eCommerceServer.Application.Features.Companies.GetAllCompany;
public sealed record GetAllCompanyQuery() : IRequest<Result<List<Company>>>;
