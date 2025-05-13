using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class Script : EntityBase<int>
{
    public string FileUrl { get; set; } = default!;
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
}
