namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class Region : ExternalEntity
{
    public required string Name { get; set; }
    public string? Code { get; set; }

    public ICollection<School> Schools { get; set; } = [];
}
