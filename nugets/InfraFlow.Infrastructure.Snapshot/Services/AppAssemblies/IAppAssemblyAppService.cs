using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppAssemblies;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppAssemblies;

public interface IAppAssemblyAppService
{
    Task<Paginate<AppAssemblyResponseDto>> GetAssembliesBySnapshotIdPaginatedAsync(Guid snapshotId, int index = 0, int size = 10, CancellationToken cancellationToken = default);
}