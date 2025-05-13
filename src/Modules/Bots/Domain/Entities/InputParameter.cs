using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class InputParameter : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;

    public string FieldName { get; set; } = default!;
    public FieldType FieldType { get; set; } = default!;

    public string? FieldDescription { get; set; }
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
    public int? DisplayOrder { get; set; }
}