namespace RiskPlatform.Modules.Bots.Application.Contracts.Requests;
public class UploadScriptResponse
{
    public int BotId { get; set; }
    public string ScriptUrl { get; set; } = default!;
}