using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class Input : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public string Name { get; set; } = default!;
    public FieldType Type { get; set; } = default!; // "string", "number", "boolean"
    public string? DefaultValue { get; set; } = default!; // If the parameter is not provided, this value will be used
}