using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppConfigurationDetails;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppConfigurationDetails;

public interface IAppConfigurationDetailAppService
{
    Task<Paginate<AppConfigurationDetailResponseDto>> GetConfigurationDetailsBySnapshotIdPaginatedAsync(Guid snapshotId, int index = 0, int size = 10, CancellationToken cancellationToken = default);
}