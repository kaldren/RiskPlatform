namespace RiskPlatform.Shared.Domain;

public abstract class EntityBase<TId>
{
    public TId Id { get; set; } = default!;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? ModifiedAt { get; set; }
}