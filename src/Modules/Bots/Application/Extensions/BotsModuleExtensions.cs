using Microsoft.Extensions.DependencyInjection;
using RiskPlatform.Modules.Bots.Application.Interfaces;
using RiskPlatform.Modules.Bots.Application.Services;

namespace RiskPlatform.Modules.Bots.Application.Extensions;
public static class BotsModuleExtensions
{
    public static IServiceCollection AddBotsModuleApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBotService, BotService>();
        return services;
    }
}
