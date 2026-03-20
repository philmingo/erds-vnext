namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class SchoolLevel : ExternalEntity
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public int SortOrder { get; set; }
}
