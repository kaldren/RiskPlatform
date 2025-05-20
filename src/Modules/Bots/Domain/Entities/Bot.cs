using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

public class Bot : EntityBase<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    // Script will be uploaded manually for now
    public string ScriptUrl { get; set; } = default!;

    // Each bot can have multiple inputs (e.g., parameters)
    public ICollection<BotInput> BotInputs { get; set; } = new List<BotInput>();

    // Each bot can have multiple filename outputs (e.g., generated files)
    public ICollection<BotOutput> BotOutputs { get; set; } = new List<BotOutput>();

    // Each bot can have multiple runs
    public ICollection<Run> Runs { get; set; } = new List<Run>();
}