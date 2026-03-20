using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class StockBalanceConfiguration : IEntityTypeConfiguration<StockBalance>
{
    public void Configure(EntityTypeBuilder<StockBalance> builder)
    {
        builder.HasIndex(sb => new { sb.ItemId, sb.StockLocationId }).IsUnique();

        builder.HasOne(sb => sb.Item)
            .WithMany(i => i.StockBalances)
            .HasForeignKey(sb => sb.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sb => sb.StockLocation)
            .WithMany(sl => sl.StockBalances)
            .HasForeignKey(sb => sb.StockLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(sb => sb.QuantityAvailable);
    }
}
