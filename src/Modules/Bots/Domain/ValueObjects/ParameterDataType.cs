namespace RiskPlatform.Modules.Bots.Domain.ValueObjects;

public sealed class ParameterDataType
{
    // Allowed field types list
    public static readonly List<string> AllowedFieldTypes = new() { "number", "string", "boolean" };

    public string Value { get; }

    public ParameterDataType(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Field type cannot be empty.", nameof(value));
        if (!AllowedFieldTypes.Contains(value))
            throw new ArgumentException($"Field type must be one of the following: {string.Join(", ", AllowedFieldTypes)}.", nameof(value));
        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(ParameterDataType type) => type.Value;

    public static ParameterDataType From(string value) => new ParameterDataType(value);
}
