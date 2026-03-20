namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class School : ExternalEntity
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Address { get; set; }

    public Guid RegionId { get; set; }
    public Region Region { get; set; } = null!;

    public Guid? SchoolLevelId { get; set; }
    public SchoolLevel? SchoolLevel { get; set; }
}
