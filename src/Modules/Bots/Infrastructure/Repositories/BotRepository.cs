using Microsoft.EntityFrameworkCore;
using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Contracts.Responses;
using RiskPlatform.Modules.Bots.Application.Interfaces;
using RiskPlatform.Modules.Bots.Domain.Entities;
using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Modules.Bots.Infrastructure.Persistence;
using System.Text.Json;

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
        var bot = new Bot
        {
            Name = request.Name,
            Description = request.Description,
            Parameters = request.InputParameters.Select(f => new BotParameter
            {
                Name = f.FieldName,
                DataType = ParameterDataType.From(f.FieldType),
                DefaultValue = f.DefaultValue,
            }).ToList(),
            Files = request.InputFileParameters.Select(f => new BotFile
            {
                Description = f.Description,
                FileType = FileType.From(f.FileType),
                IsRequired = f.IsRequired,
            }).ToList(),
        };

        _botsDbContext.Bots.Add(bot);
        await _botsDbContext.SaveChangesAsync();



        return new CreateBotResponse
        {
            Id = bot.Id,
            Name = bot.Name,
            Description = bot.Description,
        };
    }

    public async Task<CreateBotResponse> GetBotAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<CreateBotResponse> UpdateBotAsync(CreateBotRequest request)
    {
        throw new NotImplementedException();
    }
}
