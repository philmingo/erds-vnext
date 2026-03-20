namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class StockBalance : BaseEntity
{
    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public Guid StockLocationId { get; set; }
    public StockLocation StockLocation { get; set; } = null!;

    public int QuantityOnHand { get; set; }
    public int QuantityReserved { get; set; }
    public int QuantityAvailable => QuantityOnHand - QuantityReserved;
}
