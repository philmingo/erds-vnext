namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class AuditLog : BaseEntity
{
    public required string Action { get; set; }
    public required string EntityName { get; set; }
    public Guid? EntityId { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? IpAddress { get; set; }
}
