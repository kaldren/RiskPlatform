namespace RiskPlatform.Modules.Bots.Application.Contracts.Requests;
public class InputFileParameterDto
{
    public string FileType { get; set; } = default!; // e.g. ".csv"
    public bool IsRequired { get; set; }
    public string? Description { get; set; }
}