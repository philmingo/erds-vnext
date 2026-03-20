using ERDS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERDS.Infrastructure.Services;

public class PermissionService : IPermissionService
{
    private readonly IErdsDbContext _context;

    public PermissionService(IErdsDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlySet<string>> GetPermissionsAsync(string externalUserId, CancellationToken cancellationToken = default)
    {
        var permissions = await _context.UserRoles
            .Where(ur => ur.AppUser.ExternalId == externalUserId && ur.AppUser.IsActive && !ur.AppUser.IsDeleted)
            .SelectMany(ur => ur.Role.RolePermissions)
            .Select(rp => rp.Permission.Name)
            .Distinct()
            .ToListAsync(cancellationToken);

        return permissions.ToHashSet();
    }

    public async Task<bool> HasPermissionAsync(string externalUserId, string permission, CancellationToken cancellationToken = default)
    {
        return await _context.UserRoles
            .Where(ur => ur.AppUser.ExternalId == externalUserId && ur.AppUser.IsActive && !ur.AppUser.IsDeleted)
            .SelectMany(ur => ur.Role.RolePermissions)
            .AnyAsync(rp => rp.Permission.Name == permission, cancellationToken);
    }
}
