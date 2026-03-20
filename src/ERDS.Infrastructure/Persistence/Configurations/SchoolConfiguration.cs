using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.HasIndex(s => s.ExternalId);
        builder.HasIndex(s => s.RegionId);
        builder.Property(s => s.Name).HasMaxLength(300);
        builder.Property(s => s.Code).HasMaxLength(50);
        builder.Property(s => s.Address).HasMaxLength(500);

        builder.HasOne(s => s.Region)
            .WithMany(r => r.Schools)
            .HasForeignKey(s => s.RegionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
