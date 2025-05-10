namespace RiskPlatform.Modules.Bots.Application.Contracts.Requests;
public class CreateBotRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ScriptFileName { get; set; } = default!;

    // Optional: if null assume pre-uploaded
    public Stream? ScriptFileContent { get; set; }
}
