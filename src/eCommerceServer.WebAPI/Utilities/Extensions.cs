using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace eCommerceServer.WebAPI.Utilities;

public static class Extensions
{
    public static IEndpointRouteBuilder MapMyControllers(this IEndpointRouteBuilder app)
    {
        foreach (var api in ApiMethod.ApiMethods)
        {
            var bodyType = api.Body;
            var method = typeof(Extensions).GetMethod(nameof(MapPostWithBodyType), BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(bodyType);

            method?.Invoke(null, new object[] { app, api });
        }

        return app;
    }
    private static void MapPostWithBodyType<T>(IEndpointRouteBuilder app, ApiMethod api)
    {
        app.MapPost($"/api/{api.ControllerName}/{api.ActionName}",
            async (IMediator mediator, [FromBody] T request, CancellationToken cancellationToken) =>
            {
                var result = await mediator.Send(request!, cancellationToken);

                var statusCode = result!.GetType().GetProperty("StatusCode")?.GetValue(result, null);

                return Results.Json(result, statusCode: (int)statusCode!);
            }).WithGroupName(api.ControllerName);
    }
}
