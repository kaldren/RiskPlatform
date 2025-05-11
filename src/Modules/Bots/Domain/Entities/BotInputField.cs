using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class BotInputField : EntityBase<int>
{
    public int BotId { get; set; }
    public string FieldName { get; set; }
    public string FieldType { get; set; }
    public string Value { get; set; }
    public Bot Bot { get; set; }
    private BotInputField() { } // For EF Core
}
