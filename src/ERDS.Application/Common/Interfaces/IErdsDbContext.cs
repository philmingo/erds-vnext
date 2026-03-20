using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERDS.Application.Common.Interfaces;

public interface IErdsDbContext
{
    DbSet<AcademicYear> AcademicYears { get; }
    DbSet<SchoolTerm> SchoolTerms { get; }
    DbSet<Region> Regions { get; }
    DbSet<Department> Departments { get; }
    DbSet<SchoolLevel> SchoolLevels { get; }
    DbSet<Grade> Grades { get; }
    DbSet<School> Schools { get; }
    DbSet<ItemCategoryGroup> ItemCategoryGroups { get; }
    DbSet<ItemCategory> ItemCategories { get; }
    DbSet<Item> Items { get; }
    DbSet<Supplier> Suppliers { get; }
    DbSet<StockLocation> StockLocations { get; }
    DbSet<StockBalance> StockBalances { get; }
    DbSet<StockTransaction> StockTransactions { get; }
    DbSet<DistributionHeader> DistributionHeaders { get; }
    DbSet<DistributionLine> DistributionLines { get; }
    DbSet<Project> Projects { get; }
    DbSet<AppUser> AppUsers { get; }
    DbSet<AuditLog> AuditLogs { get; }
    DbSet<Role> Roles { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<RolePermission> RolePermissions { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<UserRestriction> UserRestrictions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
