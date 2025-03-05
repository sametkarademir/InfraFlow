using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.Infrastructure.AuditLog.DTOs.AppAuditLogs;

namespace InfraFlow.Infrastructure.AuditLog.Services.AppAuditLogs;

public interface IAppAuditLogAppService
{
    Task<Paginate<AppAuditLogResponseDto>> GetAuditLogsFilteredAndPaginatedAsync(GetListAppAuditLogRequestDto request, CancellationToken cancellationToken = default);
}