using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

public class Bot : EntityBase<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    // Script will be uploaded manually for now
    public string ScriptUrl { get; set; } = default!;

    // Each bot can have multiple inputs (e.g., parameters)
    public ICollection<Input> Inputs { get; set; } = new List<Input>();

    // Each bot can have multiple filename outputs (e.g., generated files)
    public ICollection<Output> Outputs { get; set; } = new List<Output>();

    // Each bot can have multiple runs
    public ICollection<Runs> Runs { get; set; } = new List<Runs>();
}