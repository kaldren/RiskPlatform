using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

//RequirementId(bigint, PK)
//BotId(FK → Bot)
//Description(nvarchar)
//FileType(nvarchar) ⟶ “txt”, “csv”…
//IsRequired(bit)

public class BotFile : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public string Description { get; set; } = default!;
    public FileType FileType { get; set; } // e.g., "txt", "csv"
    public bool IsRequired { get; set; }
}