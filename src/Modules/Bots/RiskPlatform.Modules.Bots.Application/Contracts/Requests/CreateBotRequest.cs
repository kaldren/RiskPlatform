namespace RiskPlatform.Modules.Bots.Application.Contracts.Requests;
internal class CreateBotRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
