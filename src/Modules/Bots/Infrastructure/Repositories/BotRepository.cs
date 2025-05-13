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
            Status = BotStatus.Draft,
            InputFields = request.InputParameters.Select(f => new InputParameter
            {
                FieldName = f.FieldName,
                FieldType = FieldType.From(f.FieldType),
                FieldDescription = f.FieldDescription,
                DefaultValue = f.DefaultValue,
                IsRequired = f.IsRequired,
            }).ToList(),

            InputFiles = request.InputFileParameters.Select(f => new InputFileParameter
            {
                FileExtension = FileExtension.From(f.FileExtension),
                Description = f.Description,
                IsRequired = f.IsRequired
            }).ToList(),

            OutputFiles = request.OutputFileParameters.Select(o => new OutputFileParameter
            {
                FileName = OutputFileName.From(o.FileName)
            }).ToList()
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


    public async Task<bool> CreateBotScriptAsync(int botId, string url)
    {
        _botsDbContext.Add(new Script
        {
            BotId = botId,
            FileUrl = url
        });

        return await _botsDbContext.SaveChangesAsync() > 0;
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
