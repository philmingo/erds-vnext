namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;
using ERDS.Domain.Enums;

public class DistributionHeader : AuditableEntity
{
    public required string DistributionNumber { get; set; }

    public RecipientType SourceType { get; set; }
    public Guid? SourceId { get; set; }

    public RecipientType DestinationType { get; set; }
    public Guid DestinationId { get; set; }

    public DistributionStatus Status { get; set; } = DistributionStatus.Draft;

    public string? ApprovedBy { get; set; }
    public DateTimeOffset? ApprovedAt { get; set; }
    public DateTimeOffset? IssueDate { get; set; }
    public string? Notes { get; set; }

    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }

    public ICollection<DistributionLine> Lines { get; set; } = [];
}
