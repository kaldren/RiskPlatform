using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Interfaces;

namespace RiskPlatform.Modules.Bots.API.Endpoints;
public static class UploadBotScriptEndpoint
{
    public static RouteHandlerBuilder MapUploadBotScript(this RouteGroupBuilder group)
    {
        return group.MapPost("/{botId}/script", async (
            [FromRoute]int botId,
            [FromForm] UploadBotScriptRequest request,
            IBotService botService) =>
        {
            request.BotId = botId;
            var result = await botService.UploadScriptAsync(request);

            return Results.Ok(result);
        })
        .WithName(nameof(UploadBotScriptEndpoint))
        .WithSummary("Uploads a bot script")
        .DisableAntiforgery();
    }
}

