using RiskPlatform.Modules.Bots.Domain.ValueObjects;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

public class Bot
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required PythonFileName ScriptFileName { get; set; }
}
