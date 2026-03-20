namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class StockLocation : AuditableEntity
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<StockBalance> StockBalances { get; set; } = [];
}
