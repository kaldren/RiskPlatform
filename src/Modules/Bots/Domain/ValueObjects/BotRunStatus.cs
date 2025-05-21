namespace RiskPlatform.Modules.Bots.Domain.ValueObjects;

public sealed class BotRunStatus
{
    // Allowed field types list
    public static readonly List<string> AllowedFieldTypes = new() { "running", "completed", "failed" };

    public string Value { get; }

    public BotRunStatus(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Field type cannot be empty.", nameof(value));
        if (!AllowedFieldTypes.Contains(value))
            throw new ArgumentException($"Field type must be one of the following: {string.Join(", ", AllowedFieldTypes)}.", nameof(value));
        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(BotRunStatus type) => type.Value;

    public static BotRunStatus From(string value) => new BotRunStatus(value);
}
