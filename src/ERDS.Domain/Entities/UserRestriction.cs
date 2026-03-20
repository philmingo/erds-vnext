namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class UserRestriction : BaseEntity
{
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public Guid? RegionId { get; set; }
    public Region? Region { get; set; }
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public Guid? SchoolId { get; set; }
    public School? School { get; set; }
    public bool CanViewGlobalReports { get; set; }
}
