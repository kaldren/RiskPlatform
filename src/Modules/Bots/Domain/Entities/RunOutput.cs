using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class RunOutput : EntityBase<int>
{
    /// <summary>
    /// FK → Runs.RunId
    /// </summary>
    public int RunId { get; set; }
    public Run Run { get; set; } = default!;

    /// <summary>
    /// FK → BotOutputs.Id
    /// </summary>
    public int BotOutputId { get; set; }
    public BotOutput BotOutput { get; set; } = default!;

    /// <summary>
    /// The URL where the processor uploaded the output file.
    /// </summary>
    public string Url { get; set; } = default!;
}
