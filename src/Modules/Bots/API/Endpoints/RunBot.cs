using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Interfaces;

namespace RiskPlatform.Modules.Bots.API.Endpoints;
public static class RunBotEndpoint
{
    public static RouteHandlerBuilder MapRunBot(this RouteGroupBuilder group)
    {
        return group.MapPost("/{botId}/run", async (
            [FromRoute] int botId,
            [FromBody] RunBotRequest req,
            IBotService botsService) =>
        {
            req.BotId = botId;
            var enqueued = await botsService.EnqueueBotRunAsync(req);
            return Results.Ok(enqueued);
        })
        .WithName(nameof(RunBotEndpoint))
        .WithSummary("Runs a bot");
    }
}
