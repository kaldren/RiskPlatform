using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Interfaces;

namespace RiskPlatform.Modules.Bots.API.Endpoints;
public static class CreateBotEndpoint
{
    public static RouteHandlerBuilder MapCreateBot(this RouteGroupBuilder group)
    {
        return group.MapPost("/", async (
            [FromBody] CreateBotRequest req,
            IBotService botsService) =>
        {
            var newBot = await botsService.CreateBotAsync(req);
            return Results.Ok(newBot);
        })
        .WithName(nameof(CreateBotEndpoint))
        .WithSummary("Creates a new bot")
        .DisableAntiforgery();
    }
}
