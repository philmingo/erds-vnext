using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class UserRestrictionConfiguration : IEntityTypeConfiguration<UserRestriction>
{
    public void Configure(EntityTypeBuilder<UserRestriction> builder)
    {
        builder.HasOne(ur => ur.AppUser)
            .WithMany(u => u.UserRestrictions)
            .HasForeignKey(ur => ur.AppUserId);

        builder.HasOne(ur => ur.Region)
            .WithMany()
            .HasForeignKey(ur => ur.RegionId);

        builder.HasOne(ur => ur.Department)
            .WithMany()
            .HasForeignKey(ur => ur.DepartmentId);

        builder.HasOne(ur => ur.School)
            .WithMany()
            .HasForeignKey(ur => ur.SchoolId);
    }
}
