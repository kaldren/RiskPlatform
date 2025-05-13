using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class InputFileParameter : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public FileExtension FileExtension { get; set; }
    public bool IsRequired { get; set; }
    public string? Description { get; set; }
}