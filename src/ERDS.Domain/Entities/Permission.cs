namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class Permission : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = [];
}
