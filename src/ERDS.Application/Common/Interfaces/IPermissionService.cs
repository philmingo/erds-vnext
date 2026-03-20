namespace ERDS.Application.Common.Interfaces;

public interface IPermissionService
{
    Task<IReadOnlySet<string>> GetPermissionsAsync(string externalUserId, CancellationToken cancellationToken = default);
    Task<bool> HasPermissionAsync(string externalUserId, string permission, CancellationToken cancellationToken = default);
}
