using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskPlatform.Modules.Bots.Application.Repositories;
using RiskPlatform.Modules.Bots.Infrastructure.Persistence;
using RiskPlatform.Modules.Bots.Infrastructure.Repositories;

namespace RiskPlatform.Modules.Bots.Infrastructure.Extensions;
public static class BotsModuleExtensions
{
    public static void AddBotsModuleInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IBotRepository, BotRepository>();
        services.AddDbContext<BotDbContext>(options =>
            options.UseSqlServer(config["Modules:Bots:ConnectionStrings:Default"]));
    }
}
