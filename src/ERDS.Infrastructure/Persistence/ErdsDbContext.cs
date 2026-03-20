using System.Text.Json;
using ERDS.Application.Common.Interfaces;
using ERDS.Domain.Common;
using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ERDS.Infrastructure.Persistence;

public class ErdsDbContext : DbContext, IErdsDbContext
{
    private readonly ICurrentUserService? _currentUserService;

    public ErdsDbContext(DbContextOptions<ErdsDbContext> options) : base(options)
    {
    }

    public ErdsDbContext(DbContextOptions<ErdsDbContext> options, ICurrentUserService currentUserService)
        : base(options)
    {
        _currentUserService = currentUserService;
    }

    public DbSet<AcademicYear> AcademicYears => Set<AcademicYear>();
    public DbSet<SchoolTerm> SchoolTerms => Set<SchoolTerm>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<SchoolLevel> SchoolLevels => Set<SchoolLevel>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<School> Schools => Set<School>();
    public DbSet<ItemCategoryGroup> ItemCategoryGroups => Set<ItemCategoryGroup>();
    public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<StockLocation> StockLocations => Set<StockLocation>();
    public DbSet<StockBalance> StockBalances => Set<StockBalance>();
    public DbSet<StockTransaction> StockTransactions => Set<StockTransaction>();
    public DbSet<DistributionHeader> DistributionHeaders => Set<DistributionHeader>();
    public DbSet<DistributionLine> DistributionLines => Set<DistributionLine>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<AppUser> AppUsers => Set<AppUser>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<UserRestriction> UserRestrictions => Set<UserRestriction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErdsDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        StampAuditFields();

        ChangeTracker.DetectChanges();
        var auditLogs = CreateAuditLogs();
        AuditLogs.AddRange(auditLogs);

        return await base.SaveChangesAsync(cancellationToken);
    }

    private void StampAuditFields()
    {
        var now = DateTimeOffset.UtcNow;
        var userId = _currentUserService?.UserId;

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = now;
                    entry.Entity.CreatedBy = userId;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.UpdatedBy = userId;
                    break;
            }
        }

        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
                entry.Entity.DeletedAt = now;
                entry.Entity.DeletedBy = userId;
            }
        }
    }

    private List<AuditLog> CreateAuditLogs()
    {
        var auditLogs = new List<AuditLog>();

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.Entity is AuditLog || entry.State is EntityState.Detached or EntityState.Unchanged)
                continue;

            var auditLog = new AuditLog
            {
                Action = entry.State.ToString(),
                EntityName = entry.Entity.GetType().Name,
                EntityId = entry.Entity.Id,
                UserId = _currentUserService?.UserId,
                UserName = _currentUserService?.UserName,
                IpAddress = _currentUserService?.IpAddress,
            };

            switch (entry.State)
            {
                case EntityState.Added:
                    auditLog.NewValues = SerializeValues(entry.Properties);
                    break;
                case EntityState.Modified:
                    var modified = entry.Properties.Where(p => p.IsModified).ToList();
                    auditLog.OldValues = SerializeValues(modified, useOriginal: true);
                    auditLog.NewValues = SerializeValues(modified);
                    break;
                case EntityState.Deleted:
                    auditLog.OldValues = SerializeValues(entry.Properties, useOriginal: true);
                    break;
            }

            auditLogs.Add(auditLog);
        }

        return auditLogs;
    }

    private static string SerializeValues(IEnumerable<PropertyEntry> properties, bool useOriginal = false)
    {
        var dict = new Dictionary<string, object?>();
        foreach (var prop in properties)
        {
            if (prop.Metadata.IsPrimaryKey()) continue;
            dict[prop.Metadata.Name] = useOriginal ? prop.OriginalValue : prop.CurrentValue;
        }
        return JsonSerializer.Serialize(dict);
    }
}
