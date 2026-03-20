namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class Supplier : AuditableEntity
{
    public required string Name { get; set; }
    public string? ContactPerson { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool IsDonor { get; set; }
}
