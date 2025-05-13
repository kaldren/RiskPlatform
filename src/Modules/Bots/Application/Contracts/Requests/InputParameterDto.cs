namespace RiskPlatform.Modules.Bots.Application.Contracts.Requests;
public class InputParameterDto
{
    public string FieldName { get; set; } = default!;
    public string FieldType { get; set; } = default!; // assuming string; will parse into FieldType
    public string? FieldDescription { get; set; }
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
}