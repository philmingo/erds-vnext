using ERDS.Application.Common.Interfaces;
using ERDS.Infrastructure.Persistence;
using ERDS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERDS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ErdsDbContext>(options =>
            options.UseNpgsql(connectionString, npgsqlOptions =>
                npgsqlOptions.MigrationsAssembly(typeof(ErdsDbContext).Assembly.FullName)));

        services.AddScoped<IErdsDbContext>(provider => provider.GetRequiredService<ErdsDbContext>());
        services.AddScoped<IPermissionService, PermissionService>();

        return services;
    }
}
