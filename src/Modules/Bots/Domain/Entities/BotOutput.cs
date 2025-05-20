using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class BotOutput : EntityBase<int>
{
    public int BotId { get; set; } = default!;
    public Bot Bot { get; set; } = default!;
    // The name of the output file (e.g., "output.txt")
    public string Name { get; set; } = default!;
    public ICollection<RunOutput> RunOutputs { get; set; } = new List<RunOutput>();
}
