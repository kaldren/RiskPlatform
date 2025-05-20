using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class Run : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public string Status { get; set; } = default!; // "running", "completed", "failed"
    public ICollection<RunInput> RunInputs { get; set; } = new List<RunInput>();
    public ICollection<RunOutput> RunOutputs { get; set; } = new List<RunOutput>();
}
