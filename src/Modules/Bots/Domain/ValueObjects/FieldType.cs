namespace RiskPlatform.Modules.Bots.Domain.ValueObjects;

public sealed class FieldType
{
    // Allowed field types list
    public static readonly List<string> AllowedFieldTypes = new() { "int", "string", "boolean" };

    public string Value { get; }

    public FieldType(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Field type cannot be empty.", nameof(value));
        if (!AllowedFieldTypes.Contains(value))
            throw new ArgumentException($"Field type must be one of the following: {string.Join(", ", AllowedFieldTypes)}.", nameof(value));
        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(FieldType type) => type.Value;

    public static FieldType From(string value) => new FieldType(value);
}
