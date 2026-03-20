namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class Project : AuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public string? FundingSource { get; set; }
    public string? TargetAudience { get; set; }

    public Guid? OwningDepartmentId { get; set; }
    public Department? OwningDepartment { get; set; }

    public ICollection<DistributionHeader> Distributions { get; set; } = [];
}
