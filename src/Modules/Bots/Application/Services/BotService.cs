
using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Contracts.Responses;
using RiskPlatform.Modules.Bots.Application.Interfaces;
using RiskPlatform.Modules.Bots.Application.Repositories;

namespace RiskPlatform.Modules.Bots.Application.Services;

public class BotService : IBotService
{
    private readonly IBotRepository _botRepository;

    public BotService(IBotRepository botRepository)
    {
        _botRepository = botRepository;
    }

    public async Task<CreateBotResponse> CreateBotAsync(CreateBotRequest req)
    {
        return await _botRepository.CreateBotAsync(req);
    }
}
