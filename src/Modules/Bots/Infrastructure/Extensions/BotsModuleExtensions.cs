using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskPlatform.Modules.Bots.Application.Interfaces;
using RiskPlatform.Modules.Bots.Infrastructure.Persistence;
using RiskPlatform.Modules.Bots.Infrastructure.Repositories;
using RiskPlatform.Modules.Bots.Infrastructure.Services;

namespace RiskPlatform.Modules.Bots.Infrastructure.Extensions;
public static class BotsModuleExtensions
{
    public static void AddBotsModuleInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IBotRepository, BotRepository>();
        services.AddScoped<IStorageService, AzureBlobStorageService>();

        services.AddSingleton(sp =>
        {
            var connectionString = config["Modules:Bots:AzureBlobStorage:ConnectionString"];
            return new BlobServiceClient(connectionString);
        });

        services.AddDbContext<BotDbContext>(options =>
            options.UseSqlServer(config["Modules:Bots:AzureSqlServer:ConnectionString"]));

        services.AddSingleton(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            var connStr = config["Modules:Bots:AzureServiceBus:ConnectionString"];
            return new ServiceBusClient(connStr);
        });

        services.AddScoped<IQueueService, AzureServiceBusService>();
    }
}
