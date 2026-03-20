namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class Grade : ExternalEntity
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public int SortOrder { get; set; }

    public Guid SchoolLevelId { get; set; }
    public SchoolLevel SchoolLevel { get; set; } = null!;
}
