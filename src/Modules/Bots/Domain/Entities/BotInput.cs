using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using RiskPlatform.Shared.Domain;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
public class BotInput : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;

    public string Name { get; set; } = default!;
    public FieldType Type { get; set; }

    /// <summary>
    /// If Type != File, DefaultValue is used as before.
    /// If Type == File, DefaultValue is ignored.
    /// </summary>
    public string? DefaultValue { get; set; }

    /// <summary>
    /// Comma‐separated list of allowed file extensions, e.g. "xlsx,xls"
    /// Only used when Type == File.
    /// </summary>
    public string? AllowedFileExtensions { get; set; }

    /// <summary>
    /// Maximum file size in bytes, if you want to enforce a limit.
    /// </summary>
    public long? MaxFileSizeBytes { get; set; }

    public ICollection<RunInput> RunInputs { get; set; } = new List<RunInput>();
}