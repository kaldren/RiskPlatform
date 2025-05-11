using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

public class Bot : EntityBase<int>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required PythonFileName ScriptFileName { get; set; }
}
