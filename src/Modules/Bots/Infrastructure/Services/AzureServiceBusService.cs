using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using RiskPlatform.Modules.Bots.Application.Contracts.Messages;
using RiskPlatform.Modules.Bots.Application.Interfaces;
using System.Text.Json;

namespace RiskPlatform.Modules.Bots.Infrastructure.Services;

public class AzureServiceBusService : IQueueService
{
    private readonly ServiceBusClient _client;
    private readonly string _queueName;

    public AzureServiceBusService(ServiceBusClient client, IConfiguration config)
    {
        _client = client;
        _queueName = config["Modules:Bots:AzureServiceBus:QueueName"]!;
    }

    public async Task<bool> EnqueueBotRunAsync(RunBotMessage message)
    {
        var sender = _client.CreateSender(_queueName);
        var json = JsonSerializer.Serialize(message);
        var serviceBusMessage = new ServiceBusMessage(json);

        await sender.SendMessageAsync(serviceBusMessage);

        return true;
    }
}
