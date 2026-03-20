using ERDS.Application.Common.Interfaces;
using ERDS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERDS.Infrastructure.Persistence;

public class ErdsDbContext : DbContext, IErdsDbContext
{
    public ErdsDbContext(DbContextOptions<ErdsDbContext> options) : base(options)
    {
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErdsDbContext).Assembly);
    }
}
