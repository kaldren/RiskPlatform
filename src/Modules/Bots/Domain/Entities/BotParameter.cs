using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

//ParameterId(bigint, PK)
//BotId(FK → Bot)
//Name(nvarchar)
//DataType(nvarchar) ⟶ “Int”, “String”, “Bool”…
//Description(nvarchar)
//DefaultValue(nvarchar)
//IsRequired(bit)
//DisplayOrder(int)

public class BotParameter : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public string Name { get; set; } = default!;
    public ParameterDataType DataType { get; set; }
    public string Description { get; set; } = default!;
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
}