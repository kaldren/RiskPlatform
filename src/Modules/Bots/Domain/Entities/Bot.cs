using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

//BotId(bigint, PK)
//Name(nvarchar)
//Description(nvarchar)
//ScriptUrl(nvarchar)
//CreatedAt(datetime)
//UpdatedAt(datetime)
//IsActive(bit)

public class Bot : EntityBase<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ScriptUrl { get; set; } = default!;
    public bool IsActive { get; set; }

    // Navigation properties

    // Each bot has collection of parameters
    public ICollection<BotParameter> Parameters { get; set; } = new List<BotParameter>();

    // Each bot has collection of files
    public ICollection<BotFile> Files { get; set; } = new List<BotFile>();

    // Each bot has collection of runs
    public ICollection<BotRun> Runs { get; set; } = new List<BotRun>();
}