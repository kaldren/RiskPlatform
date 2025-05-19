namespace RiskPlatform.Shared.Domain;

public abstract class EntityBase<TId>
{
    public TId Id { get; set; } = default!;

    // Store UTC time like Azure does
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; }
}