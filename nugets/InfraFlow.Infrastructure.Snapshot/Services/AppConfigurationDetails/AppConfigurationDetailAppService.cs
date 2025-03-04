using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.EntityFramework.Snapshot.Repositories;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppConfigurationDetails;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppConfigurationDetails;

public class AppConfigurationDetailAppService(IAppConfigurationDetailRepository appConfigurationDetailRepository) : IAppConfigurationDetailAppService
{
    public async Task<Paginate<AppConfigurationDetailResponseDto>> GetConfigurationDetailsBySnapshotIdPaginatedAsync(Guid snapshotId, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        var appConfigurationDetails = await appConfigurationDetailRepository.GetListAsync(
            predicate: item => item.AppSnapshotId == snapshotId,
            orderBy: q => q.OrderByDescending(item => item.CreationTime),
            index: index,
            size: size,
            cancellationToken: cancellationToken
        );
        
        return new Paginate<AppConfigurationDetailResponseDto>
        {
            Size = appConfigurationDetails.Size,
            Index = appConfigurationDetails.Index,
            Count = appConfigurationDetails.Count,
            Pages = appConfigurationDetails.Pages,
            Items = appConfigurationDetails.Items.Select(item => new AppConfigurationDetailResponseDto
            {
                Id = item.Id,
                CorrelationId = item.CorrelationId,
                AppSnapshotId = item.AppSnapshotId,
                SessionId = item.SessionId,
                CreationTime = item.CreationTime,
                CreatorId = item.CreatorId,
                Key = item.Key,
                Value = item.Value
            }).ToList()
        };
    }
}