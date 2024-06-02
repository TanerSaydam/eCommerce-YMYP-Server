using eCommerceServer.Application.Features.Companies.CreateCompany;
using eCommerceServer.Application.Features.Companies.UpdateCompany;
using eCommerceServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceServer.WebAPI.Controllers;

public class CompaniesController : ApiController
{
    public CompaniesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
