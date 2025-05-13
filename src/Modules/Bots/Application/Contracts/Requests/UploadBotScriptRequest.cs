using Microsoft.AspNetCore.Http;

namespace RiskPlatform.Modules.Bots.Application.Contracts.Requests;
public class UploadBotScriptRequest
{
    public int BotId { get; set; }
    public IFormFile ScriptFile { get; set; } = default!;
}