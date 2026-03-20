namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class ItemCategoryGroup : AuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int SortOrder { get; set; }

    public ICollection<ItemCategory> Categories { get; set; } = [];
}
