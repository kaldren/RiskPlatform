using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Contracts.Responses;

namespace RiskPlatform.Modules.Bots.Application.Repositories;
public interface IBotRepository
{
    Task<CreateBotResponse> CreateBotAsync(CreateBotRequest request);
    //Task<bool> BotExistsAsync(int botId);
    //Task<bool> BotExistsByNameAsync(string name);
    //Task<bool> BotExistsByScriptFileNameAsync(string scriptFileName);
    //Task DeleteBotAsync(int botId);
    //Task UpdateBotAsync(int botId, string name, string description, string scriptFileName);
}
