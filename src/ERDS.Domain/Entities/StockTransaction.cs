namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;
using ERDS.Domain.Enums;

public class StockTransaction : BaseEntity
{
    public TransactionType TransactionType { get; set; }

    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public int QuantityIn { get; set; }
    public int QuantityOut { get; set; }

    public Guid? SourceLocationId { get; set; }
    public StockLocation? SourceLocation { get; set; }

    public Guid? DestinationLocationId { get; set; }
    public StockLocation? DestinationLocation { get; set; }

    public Guid? DistributionLineId { get; set; }
    public DistributionLine? DistributionLine { get; set; }

    public string? Reference { get; set; }
    public string? Notes { get; set; }
}
