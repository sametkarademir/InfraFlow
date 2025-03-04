using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppSnapshots;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppSnapshots;

public interface IAppSnapshotAppService
{
    Task<Guid> GetLatestAppSnapshotIdAsync();
    
    Task<AppSnapshotResponseDto> GetSnapshotByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Paginate<AppSnapshotResponseDto>> GetSnapshotsPaginatedAsync(int index = 0, int size = 10, CancellationToken cancellationToken = default);
}
