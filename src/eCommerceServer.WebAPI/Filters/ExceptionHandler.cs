using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Text.Json;
using TS.Result;

namespace eCommerceServer.WebAPI.Filters;

public sealed class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex, CancellationToken cancellationToken)
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = MediaTypeNames.Application.Json;

        Result<string> result = Result<string>.Failure(ex.Message);

        if (ex.GetType() == typeof(ValidationException))
        {
            context.Response.StatusCode = 428;

            string errorMessage = ex.Message;
            errorMessage = errorMessage.Replace("Validation failed: ", "");
            var errorList = errorMessage.Split("\r\n -- ").ToList();
            errorList = errorList.Where(p => !string.IsNullOrEmpty(p)).ToList();
            result = Result<string>.Failure(context.Response.StatusCode, errorList);
        }

        string resultString = JsonSerializer.Serialize(result);

        await context.Response.WriteAsync(resultString);

        return true;
    }
}
