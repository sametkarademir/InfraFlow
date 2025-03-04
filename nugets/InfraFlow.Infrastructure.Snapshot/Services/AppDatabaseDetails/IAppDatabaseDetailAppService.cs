using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppDatabaseDetails;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppDatabaseDetails;

public interface IAppDatabaseDetailAppService
{
    Task<Paginate<AppDatabaseDetailResponseDto>> GetDatabaseDetailsBySnapshotIdPaginatedAsync(Guid snapshotId, int index = 0, int size = 10, CancellationToken cancellationToken = default);
}