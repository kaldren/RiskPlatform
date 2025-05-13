using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

public enum BotStatus { Draft, Ready }

public class Bot : EntityBase<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public BotStatus Status { get; set; } = BotStatus.Draft;

    public Script? Script { get; set; }
    public ICollection<InputParameter> InputFields { get; set; } = new List<InputParameter>();
    public ICollection<InputFileParameter> InputFiles { get; set; } = new List<InputFileParameter>();
    public ICollection<OutputFileParameter> OutputFiles { get; set; } = new List<OutputFileParameter>();
}