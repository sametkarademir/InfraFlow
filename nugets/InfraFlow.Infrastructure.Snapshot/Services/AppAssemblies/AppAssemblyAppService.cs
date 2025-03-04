using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.EntityFramework.Snapshot.Repositories;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppAssemblies;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppAssemblies;

public class AppAssemblyAppService(IAppAssemblyRepository appAssemblyRepository) : IAppAssemblyAppService
{
    public async Task<Paginate<AppAssemblyResponseDto>> GetAssembliesBySnapshotIdPaginatedAsync(Guid snapshotId, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        var appAssemblies = await appAssemblyRepository.GetListAsync(
            predicate: item => item.AppSnapshotId == snapshotId,
            orderBy: q => q.OrderByDescending(item => item.CreationTime),
            index: index,
            size: size,
            cancellationToken: cancellationToken
        );
        
        return new Paginate<AppAssemblyResponseDto>
        {
            Size = appAssemblies.Size,
            Index = appAssemblies.Index,
            Count = appAssemblies.Count,
            Pages = appAssemblies.Pages,
            Items = appAssemblies.Items.Select(item => new AppAssemblyResponseDto
            {
                Id = item.Id,
                CorrelationId = item.CorrelationId,
                AppSnapshotId = item.AppSnapshotId,
                SessionId = item.SessionId,
                CreationTime = item.CreationTime,
                CreatorId = item.CreatorId,
                Name = item.Name,
                Version = item.Version,
                Culture = item.Culture,
                PublicKeyToken = item.PublicKeyToken,
                Location = item.Location
            }).ToList()
        };
    }
}