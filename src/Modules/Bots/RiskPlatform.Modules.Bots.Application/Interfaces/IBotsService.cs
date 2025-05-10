namespace RiskPlatform.Modules.Bots.Application.Interfaces;

internal interface IBotsService
{
    Task<Guid> CreateBotAsync();
}
