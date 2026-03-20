namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class Department : AuditableEntity
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}
