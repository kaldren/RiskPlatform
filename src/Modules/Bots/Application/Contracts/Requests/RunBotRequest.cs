using Microsoft.AspNetCore.Http;

namespace RiskPlatform.Modules.Bots.Application.Contracts.Requests;

public class RunBotRequest
{
    public int BotId { get; set; }
    public List<InputParameterDto> InputParameters { get; set; } = new();
    public List<InputFileParameterDto> InputFileParameters { get; set; } = new();
    public List<OutputFileParameterDto> OutputFileParameters { get; set; } = new();
}
