
using RiskPlatform.Modules.Bots.Application.Contracts.Messages;
using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Contracts.Responses;
using RiskPlatform.Modules.Bots.Application.Interfaces;

namespace RiskPlatform.Modules.Bots.Application.Services;

public class BotService : IBotService
{
    private readonly IBotRepository _botRepository;
    private readonly IStorageService _botBlobStorageService;
    private readonly IQueueService _queueService;

    public BotService(
        IBotRepository botRepository, 
        IStorageService botBlobStorageService,
        IQueueService queueService)
    {
        _botRepository = botRepository;
        _botBlobStorageService = botBlobStorageService;
        _queueService = queueService;
    }

    public async Task<CreateBotResponse> CreateBotAsync(CreateBotRequest req)
    {
        var newBot = await _botRepository.CreateBotAsync(req);

        return newBot;
    }

    public Task<bool> EnqueueBotRunAsync(RunBotRequest request)
    {
        return _queueService.EnqueueBotRunAsync(new RunBotMessage
        {
            BotId = request.BotId,
            InputFileParameters = request.InputFileParameters,
            InputParameters = request.InputParameters,
            OutputFileParameters = request.OutputFileParameters
        });
    }

    public async Task<UploadScriptResponse> UploadScriptAsync(UploadBotScriptRequest request)
    {
        var url = await _botBlobStorageService.UploadScriptAsync(request.BotId, request.ScriptFile);

        return new UploadScriptResponse
        {
            BotId = request.BotId,
            ScriptUrl = url
        };
    }
}
