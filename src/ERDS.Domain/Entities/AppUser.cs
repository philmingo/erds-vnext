namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class AppUser : AuditableEntity
{
    public required string ExternalId { get; set; }
    public required string DisplayName { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; } = true;
}
