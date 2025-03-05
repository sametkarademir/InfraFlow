using InfraFlow.Domain.AuditLog.Enums;
using InfraFlow.Domain.Core.Dtos;
using InfraFlow.Infrastructure.AuditLog.DTOs.AppEntityPropertyChanges;

namespace InfraFlow.Infrastructure.AuditLog.DTOs.AppAuditLogs;

public class AppAuditLogResponseDto : CreationAuditedEntityDto<Guid>
{
    public string EntityId { get; set; } = null!;
    public string EntityName { get; set; } = null!;
    public EntityState EntityState { get; set; }
    
    public List<AppEntityPropertyChangeResponseDto>? AppEntityPropertyChanges { get; set; }
}