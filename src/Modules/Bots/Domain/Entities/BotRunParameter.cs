using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

//RunParamId(bigint, PK)
//RunId(FK → BotRun)
//ParameterId(FK → BotParameter)
//Value(nvarchar)

public class BotRunParameter : EntityBase<int>
{
    public int BotRunId { get; set; }
    public BotRun BotRun { get; set; } = default!;
    public int BotParameterId { get; set; }
    public BotParameter BotParameter { get; set; } = default!;
    public string Value { get; set; } = default!;
}
