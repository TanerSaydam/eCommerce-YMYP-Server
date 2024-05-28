using eCommerceServer.Application;
using eCommerceServer.Infrastructure;
using FluentValidation;
using System.Net.Mime;
using System.Text.Json;
using TS.Result;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
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
    }
});

app.UseAuthorization();

app.MapControllers();

app.Run();
