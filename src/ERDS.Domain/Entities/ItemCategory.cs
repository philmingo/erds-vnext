namespace ERDS.Domain.Entities;

using ERDS.Domain.Common;

public class ItemCategory : AuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int SortOrder { get; set; }

    public Guid ItemCategoryGroupId { get; set; }
    public ItemCategoryGroup ItemCategoryGroup { get; set; } = null!;

    public ICollection<Item> Items { get; set; } = [];
}
