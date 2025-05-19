using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class Output : EntityBase<int>
{
    public int Id { get; set; }
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public string Name { get; set; }
}
