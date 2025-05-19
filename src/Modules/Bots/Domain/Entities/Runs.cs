using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class Runs : EntityBase<long>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public string Status { get; set; } = default!; // "running", "completed", "failed"
}
