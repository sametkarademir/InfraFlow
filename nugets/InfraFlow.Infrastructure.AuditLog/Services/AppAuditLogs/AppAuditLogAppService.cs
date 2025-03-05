using InfraFlow.EntityFramework.AuditLog.Repositories;
using InfraFlow.EntityFramework.Core.Extensions;
using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.Infrastructure.AuditLog.DTOs.AppAuditLogs;
using InfraFlow.Infrastructure.AuditLog.DTOs.AppEntityPropertyChanges;

namespace InfraFlow.Infrastructure.AuditLog.Services.AppAuditLogs;

public class AppAuditLogAppService(IAppAuditLogRepository auditLogRepository) : IAppAuditLogAppService
{
    public async Task<Paginate<AppAuditLogResponseDto>> GetAuditLogsFilteredAndPaginatedAsync(GetListAppAuditLogRequestDto request, CancellationToken cancellationToken = default)
    {
        var queryable = auditLogRepository.Query();
        
        if (request.CorrelationId.HasValue)
        {
            queryable = queryable.Where(item => item.CorrelationId == request.CorrelationId);
        }
        
        if (request.AppSnapshotId.HasValue)
        {
            queryable = queryable.Where(item => item.AppSnapshotId == request.AppSnapshotId);
        }
        
        if (request.SessionId.HasValue)
        {
            queryable = queryable.Where(item => item.SessionId == request.SessionId);
        }
        
        if (!string.IsNullOrWhiteSpace(request.EntityId))
        {
            queryable = queryable.Where(item => item.EntityId == request.EntityId);
        }
        
        if (!string.IsNullOrWhiteSpace(request.EntityName))
        {
            queryable = queryable.Where(item => item.EntityName == request.EntityName);
        }
        
        if (request.EntityState.HasValue)
        {
            queryable = queryable.Where(item => item.EntityState == request.EntityState);
        }
        
        var auditLogs = await queryable
            .OrderByDescending(item => item.CreationTime)
            .Skip(request.Index)
            .Take(request.Size)
            .ToPaginateAsync(request.Index, request.Size, cancellationToken);

        return new Paginate<AppAuditLogResponseDto>
        {
            Size = auditLogs.Size,
            Index = auditLogs.Index,
            Count = auditLogs.Count,
            Pages = auditLogs.Pages,
            Items = auditLogs.Items.Select(item => new AppAuditLogResponseDto
            {
                Id = item.Id,
                CorrelationId = item.CorrelationId,
                AppSnapshotId = item.AppSnapshotId,
                SessionId = item.SessionId,
                EntityId = item.EntityId,
                EntityName = item.EntityName,
                EntityState = item.EntityState,
                AppEntityPropertyChanges = item.AppEntityPropertyChanges?.Select(propertyChange => new AppEntityPropertyChangeResponseDto
                {
                    Id = propertyChange.Id,
                    CorrelationId = propertyChange.CorrelationId,
                    AppSnapshotId = propertyChange.AppSnapshotId,
                    SessionId = propertyChange.SessionId,
                    CreationTime = propertyChange.CreationTime,
                    CreatorId = propertyChange.CreatorId,
                    PropertyName = propertyChange.PropertyName,
                    PropertyTypeFullName = propertyChange.PropertyTypeFullName,
                    AuditLogId = propertyChange.AuditLogId,
                    NewValue = propertyChange.NewValue,
                    OriginalValue = propertyChange.OriginalValue,
                }).ToList(),
                CreationTime = item.CreationTime,
                CreatorId = item.CreatorId
            }).ToList()
        };
    }
}