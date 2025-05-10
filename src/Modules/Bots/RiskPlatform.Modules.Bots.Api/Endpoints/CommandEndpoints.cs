using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RiskPlatform.Modules.Bots.API.Endpoints;
public static class CommandEndpoints
{
    public static RouteGroupBuilder MapCommandEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/bots")
                          .WithTags("Bots");

        // Create a new bot
        group.MapPost("/bots", async (HttpContext context) =>
        {
            // Simulate bot creation
            await Task.Delay(1000);
            return Results.Ok(new { Message = "Bot created successfully!" });
        });

        return group;
    }
}