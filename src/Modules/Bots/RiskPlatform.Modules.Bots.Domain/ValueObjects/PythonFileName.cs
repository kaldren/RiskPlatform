namespace RiskPlatform.Modules.Bots.Domain.ValueObjects;
internal sealed class PythonFileName
{
    public string Value { get; }

    public PythonFileName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Script file name cannot be empty.", nameof(value));

        if (!value.EndsWith(".py", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Script file must have a .py extension.", nameof(value));

        if (value.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            throw new ArgumentException("Script file name contains invalid characters.", nameof(value));

        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(PythonFileName name) => name.Value;
}
