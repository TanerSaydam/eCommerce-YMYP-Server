using eCommerceServer.WebAPI.Utilities;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace eCommerceServer.WebAPI.Filters;

public class ApiMethodsDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var apiMethod in ApiMethod.ApiMethods)
        {
            var bodyType = apiMethod.Body;
            var operation = new OpenApiOperation
            {
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = apiMethod.ControllerName } },
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse { Description = "Success" }
                },
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = context.SchemaGenerator.GenerateSchema(bodyType, context.SchemaRepository)
                        }
                    }
                }
            };

            swaggerDoc.Paths.Add($"/api/{apiMethod.ControllerName}/{apiMethod.ActionName}", new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Post] = operation
                }
            });
        }
    }
}