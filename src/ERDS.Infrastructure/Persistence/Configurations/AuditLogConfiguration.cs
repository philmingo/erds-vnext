using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERDS.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasIndex(al => al.EntityName);
        builder.HasIndex(al => al.CreatedAt);
        builder.Property(al => al.Action).HasMaxLength(100);
        builder.Property(al => al.EntityName).HasMaxLength(200);
        builder.Property(al => al.UserId).HasMaxLength(200);
        builder.Property(al => al.UserName).HasMaxLength(300);
        builder.Property(al => al.IpAddress).HasMaxLength(50);
    }
}
