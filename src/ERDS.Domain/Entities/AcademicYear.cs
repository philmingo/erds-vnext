namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class AcademicYear : AuditableEntity
{
    public required string Name { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public bool IsCurrent { get; set; }

    public ICollection<SchoolTerm> Terms { get; set; } = [];
}
