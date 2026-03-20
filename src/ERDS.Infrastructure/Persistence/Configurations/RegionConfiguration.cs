using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasIndex(r => r.Name).IsUnique();
        builder.HasIndex(r => r.ExternalId);
        builder.Property(r => r.Name).HasMaxLength(200);
        builder.Property(r => r.Code).HasMaxLength(50);
    }
}
