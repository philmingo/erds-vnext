using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class DistributionLineConfiguration : IEntityTypeConfiguration<DistributionLine>
{
    public void Configure(EntityTypeBuilder<DistributionLine> builder)
    {
        builder.HasOne(dl => dl.DistributionHeader)
            .WithMany(dh => dh.Lines)
            .HasForeignKey(dl => dl.DistributionHeaderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(dl => dl.Item)
            .WithMany()
            .HasForeignKey(dl => dl.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
