using RiskPlatform.Modules.Bots.Application.Contracts.Requests;
using RiskPlatform.Modules.Bots.Application.Contracts.Responses;

namespace RiskPlatform.Modules.Bots.Application.Interfaces;

public interface IBotService
{
    Task<CreateBotResponse> CreateBotAsync(CreateBotRequest request);
}
