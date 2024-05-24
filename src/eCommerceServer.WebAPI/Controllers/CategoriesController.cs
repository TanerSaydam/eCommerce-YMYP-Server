﻿using eCommerceServer.Application.Features.Categories.CreateCategory;
using eCommerceServer.Application.Features.Categories.GetAllCategory;
using eCommerceServer.Application.Features.Categories.RemoveCategory;
using eCommerceServer.Application.Features.Categories.UpdateCategory;
using eCommerceServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceServer.WebAPI.Controllers;

public class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellation)
    {
        var result = await _mediator.Send(new DeleteCategoryByIdCommand(Id), cancellation);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellation)
    {
        var result = await _mediator.Send(new GetAllCategoryQuery(), cancellation);
        return StatusCode(result.StatusCode, result);
    }
}
