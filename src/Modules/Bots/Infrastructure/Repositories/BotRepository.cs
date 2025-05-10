using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Contracts.Responses;
using RiskPlatform.Modules.Bots.Application.Repositories;
using RiskPlatform.Modules.Bots.Domain.Entities;
using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Modules.Bots.Infrastructure.Persistence;

namespace RiskPlatform.Modules.Bots.Infrastructure.Repositories;

public class BotRepository : IBotRepository
{
    private readonly BotDbContext _botsDbContext;

    public BotRepository(BotDbContext botsDbContext)
    {
        _botsDbContext = botsDbContext;
    }

    public async Task<CreateBotResponse> CreateBotAsync(CreateBotRequest request)
    {
        Guid botId = Guid.NewGuid();

        _botsDbContext.Bots.Add(new Bot
        {
            Id = botId,
            Name = request.Name,
            Description = request.Description,
            ScriptFileName = new PythonFileName(request.ScriptFileName)
        });

        await _botsDbContext.SaveChangesAsync();

        return new CreateBotResponse
        {
            Id = botId,
            Name = request.Name,
            Description = request.Description,
            ScriptFileName = request.ScriptFileName
        };
    }
}
