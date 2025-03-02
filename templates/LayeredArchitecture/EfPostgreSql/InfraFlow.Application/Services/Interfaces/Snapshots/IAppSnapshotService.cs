using InfraFlow.Application.DTOs.AppSnapshots;
using InfraFlow.Application.DTOs.Common;

namespace InfraFlow.Application.Services.Interfaces.Snapshots;

public interface IAppSnapshotService
{
    Task<Guid> GetLatestAppSnapshotIdAsync();
    
    Task<AppSnapshotResponseDto> GetSnapshotByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PaginatedResponseDto<AppSnapshotResponseDto>> GetSnapshotsPaginatedAsync(PaginateRequestDto request, CancellationToken cancellationToken = default);
}