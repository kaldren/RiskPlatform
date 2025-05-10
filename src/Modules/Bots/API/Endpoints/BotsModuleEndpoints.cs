using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Interfaces;

namespace RiskPlatform.Modules.Bots.API.Endpoints;
public static class BotsModuleEndpoints
{
    public static RouteGroupBuilder MapBotsModuleEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/bots")
                          .WithTags("Bots");

        // Create a new bot
        group.MapPost("/", async (CreateBotRequest req, IBotService botsService, HttpContext context) =>
        {
            // Simulate bot creation
            var newBot = await botsService.CreateBotAsync(req);
            return Results.Ok(new { Message = "Bot created successfully!" });
        });

        // Get all bots
        group.MapGet("/", async (HttpContext context) =>
        {
            // Simulate fetching all bots
            await Task.Delay(1000);
            return Results.Ok(new[]
            {
                new { Id = 1, Name = "Bot1" },
                new { Id = 2, Name = "Bot2" }
            });
        });

        // Get a bot by ID
        group.MapGet("/{id:int}", async (int id, HttpContext context) =>
        {
            // Simulate fetching a bot by ID
            await Task.Delay(1000);
            return Results.Ok(new { Id = id, Name = $"Bot{id}" });
        });

        return group;
    }
}