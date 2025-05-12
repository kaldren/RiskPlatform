using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RiskPlatform.Modules.Bots.API.Endpoints;
public static class GetAllBotsEndpoint
{
    public static RouteHandlerBuilder MapGetAllBots(this RouteGroupBuilder group)
    {
        return group.MapGet("/", async (HttpContext context) =>
        {
            // Simulate fetching all bots
            await Task.Delay(1000);
            return Results.Ok(new[]
            {
                new { Id = 1, Name = "Bot1" },
                new { Id = 2, Name = "Bot2" }
            });
        })
        .WithName(nameof(GetAllBotsEndpoint))
        .WithSummary("Gets all bots.");
    }
}
