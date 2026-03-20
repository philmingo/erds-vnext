namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class Item : AuditableEntity
{
    public required string Name { get; set; }
    public string? Sku { get; set; }
    public string? Description { get; set; }
    public string? UnitOfMeasure { get; set; }

    public Guid ItemCategoryId { get; set; }
    public ItemCategory ItemCategory { get; set; } = null!;

    public ICollection<StockBalance> StockBalances { get; set; } = [];
}
