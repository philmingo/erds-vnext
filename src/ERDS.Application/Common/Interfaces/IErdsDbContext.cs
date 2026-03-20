using Microsoft.EntityFrameworkCore;

namespace ERDS.Application.Common.Interfaces;

public interface IErdsDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
