using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.EntityFramework.Snapshot.Repositories;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppDatabaseDetails;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppDatabaseTableDetails;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppDatabaseDetails;

public class AppDatabaseDetailAppService(IAppDatabaseDetailRepository appDatabaseDetailRepository) : IAppDatabaseDetailAppService
{
    public async Task<Paginate<AppDatabaseDetailResponseDto>> GetDatabaseDetailsBySnapshotIdPaginatedAsync(Guid snapshotId, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        var appDatabaseDetails = await appDatabaseDetailRepository.GetListAsync(
            predicate: item => item.AppSnapshotId == snapshotId,
            orderBy: q => q.OrderByDescending(item => item.CreationTime),
            index: index,
            size: size,
            cancellationToken: cancellationToken
        );
        
        return new Paginate<AppDatabaseDetailResponseDto>
        {
            Size = appDatabaseDetails.Size,
            Index = appDatabaseDetails.Index,
            Count = appDatabaseDetails.Count,
            Pages = appDatabaseDetails.Pages,
            Items = appDatabaseDetails.Items.Select(item => new AppDatabaseDetailResponseDto
            {
                Id = item.Id,
                CorrelationId = item.CorrelationId,
                AppSnapshotId = item.AppSnapshotId,
                SessionId = item.SessionId,
                CreationTime = item.CreationTime,
                CreatorId = item.CreatorId,
                Host = item.Host,
                DatabaseName = item.DatabaseName,
                DatabaseVersion = item.DatabaseVersion,
                TableCount = item.TableCount,
                AppDatabaseTableDetails = item.AppDatabaseTableDetails?.Select(table => new AppDatabaseTableDetailResponseDto
                {
                    Id = table.Id,
                    CorrelationId = table.CorrelationId,
                    AppSnapshotId = table.AppSnapshotId,
                    AppDatabaseDetailId = table.AppDatabaseDetailId,
                    SessionId = table.SessionId,
                    CreationTime = table.CreationTime,
                    CreatorId = table.CreatorId,
                    TableName = table.TableName,
                    RecordCount = table.RecordCount,
                }).ToList()
            }).ToList()
        };
    }
}