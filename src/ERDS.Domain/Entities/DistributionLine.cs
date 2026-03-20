namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class DistributionLine : AuditableEntity
{
    public Guid DistributionHeaderId { get; set; }
    public DistributionHeader DistributionHeader { get; set; } = null!;

    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public int QuantityRequested { get; set; }
    public int QuantityApproved { get; set; }
    public int QuantityIssued { get; set; }
    public int QuantityReceived { get; set; }
    public string? Remarks { get; set; }
}
