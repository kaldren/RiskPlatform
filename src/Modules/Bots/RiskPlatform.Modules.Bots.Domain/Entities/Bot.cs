using RiskPlatform.Modules.Bots.Domain.ValueObjects;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

internal class Bot
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required PythonFileName ScriptFileName { get; set; }
}
