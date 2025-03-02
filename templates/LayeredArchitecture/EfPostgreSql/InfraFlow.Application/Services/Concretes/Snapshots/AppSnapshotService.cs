using AutoMapper;
using InfraFlow.Application.DTOs.AppSnapshots;
using InfraFlow.Application.DTOs.Common;
using InfraFlow.Application.Services.Interfaces.Snapshots;
using InfraFlow.Domain.Core.Aggregates.Entities;
using InfraFlow.EntityFramework.Snapshot.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace InfraFlow.Application.Services.Concretes.Snapshots;

public class AppSnapshotService(
    IMemoryCache memoryCache,
    IMapper mapper,
    IAppSnapshotRepository appSnapshotRepository)
    : IAppSnapshotService
{
    public async Task<Guid> GetLatestAppSnapshotIdAsync()
    {
        memoryCache.TryGetValue(nameof(IAppSnapshotEntity), out Guid snapshotId);
        
        if (snapshotId == Guid.Empty || snapshotId == default)
        {
            var appSnapshot = await appSnapshotRepository.FirstOrDefaultAsync(
                orderBy: q => q.OrderByDescending(item => item.CreationTime)
            );

            snapshotId = appSnapshot!.Id;
            memoryCache.Set(nameof(IAppSnapshotEntity), snapshotId);
        }
   
        return snapshotId;
    }

    public async Task<AppSnapshotResponseDto> GetSnapshotByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var appSnapshot = await appSnapshotRepository.FirstOrDefaultAsync(item => item.Id == id, cancellationToken: cancellationToken);
        
        if (appSnapshot == null)
        {
            throw new Exception("Snapshot not found!");
        }
        
        return mapper.Map<AppSnapshotResponseDto>(appSnapshot);
    }

    public async Task<PaginatedResponseDto<AppSnapshotResponseDto>> GetSnapshotsPaginatedAsync(PaginateRequestDto request, CancellationToken cancellationToken = default)
    {
        var appSnapshots = await appSnapshotRepository.GetListAsync(
            orderBy: q => q.OrderByDescending(item => item.CreationTime),
            index: request.PageIndex,
            size: request.PageSize,
            cancellationToken: cancellationToken
        );
        
        return mapper.Map<PaginatedResponseDto<AppSnapshotResponseDto>>(appSnapshots);
    }
}