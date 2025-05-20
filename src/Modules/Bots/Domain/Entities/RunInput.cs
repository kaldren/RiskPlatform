using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class RunInput : EntityBase<int>
{
    /// <summary>
    /// FK → Runs.RunId
    /// </summary>
    public int RunId { get; set; }
    public Run Run { get; set; } = default!;

    /// <summary>
    /// FK → BotInputs.Id
    /// </summary>
    public int BotInputId { get; set; }
    public BotInput BotInput { get; set; } = default!;


    /// <summary>
    /// For parameter‐type inputs, the literal value; 
    /// for file‐type inputs, you can store the blob URL here instead.
    /// </summary>
    public string Value { get; set; } = default!;
}
