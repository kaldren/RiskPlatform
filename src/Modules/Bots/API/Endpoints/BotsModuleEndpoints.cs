using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RiskPlatform.Modules.Bots.API.Endpoints;
public static class BotsModuleEndpoints
{
    public static RouteGroupBuilder MapBotsModuleEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/bots")
                          .WithTags("Bots");

        group.MapCreateBot();
        group.MapGetAllBots();

        return group;
    }
}