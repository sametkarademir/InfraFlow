using InfraFlow.Domain.Core.Aggregates.Entities;
using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.EntityFramework.Snapshot.Repositories;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppSnapshots;
using Microsoft.Extensions.Caching.Memory;

namespace InfraFlow.Infrastructure.Snapshot.Services.AppSnapshots;

public class AppSnapshotAppService(
    IMemoryCache memoryCache,
    IAppSnapshotRepository appSnapshotRepository)
    : IAppSnapshotAppService
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

        return new AppSnapshotResponseDto
        {
            Id = appSnapshot.Id,
            CorrelationId = appSnapshot.CorrelationId,
            AppSnapshotId = appSnapshot.AppSnapshotId,
            SessionId = appSnapshot.SessionId,
            CreationTime = appSnapshot.CreationTime,
            CreatorId = appSnapshot.CreatorId,
            ApplicationName = appSnapshot.ApplicationName,
            ApplicationVersion = appSnapshot.ApplicationVersion,
            Environment = appSnapshot.Environment,
            MachineName = appSnapshot.MachineName,
            MachineOsVersion = appSnapshot.MachineOsVersion,
            Platform = appSnapshot.Platform,
            CultureInfo = appSnapshot.CultureInfo,
            CpuCoreCount = appSnapshot.CpuCoreCount,
            CpuArchitecture = appSnapshot.CpuArchitecture,
            TotalRam = appSnapshot.TotalRam,
            TotalDiskSpace = appSnapshot.TotalDiskSpace,
            Hostname = appSnapshot.Hostname,
            InterfaceNames = appSnapshot.InterfaceName?.Split(',').ToList(),
            IpAddresses = appSnapshot.IpAddress?.Split(',').ToList(),
        };
    }

    public async Task<Paginate<AppSnapshotResponseDto>> GetSnapshotsPaginatedAsync(int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        var appSnapshots = await appSnapshotRepository.GetListAsync(
            orderBy: q => q.OrderByDescending(item => item.CreationTime),
            index: index,
            size: size,
            cancellationToken: cancellationToken
        );
        
        return new Paginate<AppSnapshotResponseDto>
        {
            Size = appSnapshots.Size,
            Index = appSnapshots.Index,
            Count = appSnapshots.Count,
            Pages = appSnapshots.Pages,
            Items = appSnapshots.Items.Select(item => new AppSnapshotResponseDto
                {
                    Id = item.Id,
                    CorrelationId = item.CorrelationId,
                    AppSnapshotId = item.AppSnapshotId,
                    SessionId = item.SessionId,
                    CreationTime = item.CreationTime,
                    CreatorId = item.CreatorId,
                    ApplicationName = item.ApplicationName,
                    ApplicationVersion = item.ApplicationVersion,
                    Environment = item.Environment,
                    MachineName = item.MachineName,
                    MachineOsVersion = item.MachineOsVersion,
                    Platform = item.Platform,
                    CultureInfo = item.CultureInfo,
                    CpuCoreCount = item.CpuCoreCount,
                    CpuArchitecture = item.CpuArchitecture,
                    TotalRam = item.TotalRam,
                    TotalDiskSpace = item.TotalDiskSpace,
                    Hostname = item.Hostname,
                    InterfaceNames = item.InterfaceName?.Split(',').ToList(),
                    IpAddresses = item.IpAddress?.Split(',').ToList(),
                }).ToList(),
        };
    }
}