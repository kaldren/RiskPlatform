using RiskPlatform.Modules.Bots.Application.Contracts.Requests;

namespace RiskPlatform.Modules.Bots.Application.Contracts.Messages;

public class RunBotMessage
{
    public int BotId { get; set; }
    public List<InputParameterDto> InputParameters { get; set; } = new();
    public List<InputFileParameterDto> InputFileParameters { get; set; } = new();
    public List<OutputFileParameterDto> OutputFileParameters { get; set; } = new();
    public Guid RunId { get; set; } = Guid.NewGuid();
}