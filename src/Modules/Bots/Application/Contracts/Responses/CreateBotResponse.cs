namespace RiskPlatform.Modules.Bots.Application.Contracts.Responses;

public class CreateBotResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ScriptFileName { get; set; } = default!;
}
