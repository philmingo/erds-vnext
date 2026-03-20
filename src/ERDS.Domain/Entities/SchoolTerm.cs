namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class SchoolTerm : AuditableEntity
{
    public required string Name { get; set; }
    public int TermNumber { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }

    public Guid AcademicYearId { get; set; }
    public AcademicYear AcademicYear { get; set; } = null!;
}
