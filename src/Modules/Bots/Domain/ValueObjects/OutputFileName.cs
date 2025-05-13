using System.ComponentModel.DataAnnotations.Schema;

namespace RiskPlatform.Modules.Bots.Domain.ValueObjects;

[NotMapped]
public sealed class OutputFileName
{
    private static readonly string[] AllowedExtensions = [".txt", ".xlsx", ".csv"];

    public string Value { get; }
    public OutputFileName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("File name cannot be empty.", nameof(value));

        if (!AllowedExtensions.Any(ext => value.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
            throw new ArgumentException($"File must have one of the following extensions: {string.Join(", ", AllowedExtensions)}");

        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(OutputFileName name) => name.Value;

    public static OutputFileName From(string value) => new OutputFileName(value);

    private OutputFileName() { } // For EF Core
}
