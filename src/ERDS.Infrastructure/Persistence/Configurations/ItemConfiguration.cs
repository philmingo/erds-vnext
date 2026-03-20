using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasIndex(i => i.Sku).IsUnique().HasFilter("\"Sku\" IS NOT NULL");
        builder.Property(i => i.Name).HasMaxLength(300);
        builder.Property(i => i.Sku).HasMaxLength(100);
        builder.Property(i => i.UnitOfMeasure).HasMaxLength(50);

        builder.HasOne(i => i.ItemCategory)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.ItemCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
