using ERDS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERDS.Infrastructure.Persistence;

public class ErdsDbContext : DbContext, IErdsDbContext
{
    public ErdsDbContext(DbContextOptions<ErdsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErdsDbContext).Assembly);
    }
}
