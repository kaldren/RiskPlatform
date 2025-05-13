using Microsoft.AspNetCore.Http;

namespace RiskPlatform.Modules.Bots.Application.Interfaces;
public interface IStorageService
{
    Task<string> UploadScriptAsync(int botId, IFormFile file);
}
