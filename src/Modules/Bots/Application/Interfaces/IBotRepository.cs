using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Contracts.Responses;

namespace RiskPlatform.Modules.Bots.Application.Interfaces;
public interface IBotRepository
{
    Task<CreateBotResponse> CreateBotAsync(CreateBotRequest request);
    Task<CreateBotResponse> GetBotAsync(string name);
    //Task<CreateBotResponse> GetBotAsync(int botId);

    //Task<bool> BotExistsAsync(int botId);
    //Task<bool> BotExistsByNameAsync(string name);
    //Task<bool> BotExistsByScriptFileNameAsync(string scriptFileName);
    //Task DeleteBotAsync(int botId);
    Task<CreateBotResponse> UpdateBotAsync(CreateBotRequest request);
}
