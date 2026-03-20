namespace ERDS.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
