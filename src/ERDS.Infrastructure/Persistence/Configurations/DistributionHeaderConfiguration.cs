using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class DistributionHeaderConfiguration : IEntityTypeConfiguration<DistributionHeader>
{
    public void Configure(EntityTypeBuilder<DistributionHeader> builder)
    {
        builder.HasIndex(dh => dh.DistributionNumber).IsUnique();
        builder.HasIndex(dh => dh.Status);
        builder.Property(dh => dh.DistributionNumber).HasMaxLength(50);
        builder.Property(dh => dh.ApprovedBy).HasMaxLength(200);

        builder.HasOne(dh => dh.Project)
            .WithMany(p => p.Distributions)
            .HasForeignKey(dh => dh.ProjectId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(dh => dh.Status)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(dh => dh.SourceType)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(dh => dh.DestinationType)
            .HasConversion<string>()
            .HasMaxLength(50);
    }
}
