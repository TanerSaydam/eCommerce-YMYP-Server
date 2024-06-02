using eCommerceServer.Application;
using eCommerceServer.Infrastructure;
using eCommerceServer.WebAPI.Filters;
using eCommerceServer.WebAPI.Utilities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "eCommerceServer API", Version = "v1" });
    c.DocumentFilter<ApiMethodsDocumentFilter>();
});

builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapMyControllers();

app.MapControllers();

app.Run();
