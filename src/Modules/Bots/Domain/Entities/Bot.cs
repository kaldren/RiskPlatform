using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

public class Bot : EntityBase<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public PythonFileName ScriptFileName { get; set; }
    public ICollection<BotInputField> InputFields { get; set; }
    public ICollection<BotOutputFile> OutputFiles { get; set; }
}
