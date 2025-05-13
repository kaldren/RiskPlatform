using RiskPlatform.Modules.Bots.Application.Contracts.Messages;

namespace RiskPlatform.Modules.Bots.Application.Interfaces;
public interface IQueueService
{
    Task<bool> EnqueueBotRunAsync(RunBotMessage message);
}
