namespace ERDS.Domain.Common;

public abstract class ExternalEntity : AuditableEntity
{
    public string? ExternalId { get; set; }
    public string? SourceSystem { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
}
