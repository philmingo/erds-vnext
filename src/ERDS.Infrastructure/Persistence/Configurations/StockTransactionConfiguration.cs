using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class StockTransactionConfiguration : IEntityTypeConfiguration<StockTransaction>
{
    public void Configure(EntityTypeBuilder<StockTransaction> builder)
    {
        builder.HasIndex(st => st.ItemId);
        builder.HasIndex(st => st.CreatedAt);
        builder.Property(st => st.Reference).HasMaxLength(200);

        builder.HasOne(st => st.Item)
            .WithMany()
            .HasForeignKey(st => st.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(st => st.SourceLocation)
            .WithMany()
            .HasForeignKey(st => st.SourceLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(st => st.DestinationLocation)
            .WithMany()
            .HasForeignKey(st => st.DestinationLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(st => st.DistributionLine)
            .WithMany()
            .HasForeignKey(st => st.DistributionLineId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
