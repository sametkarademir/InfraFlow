using InfraFlow.Domain.Core.Dtos;

namespace InfraFlow.Infrastructure.AuditLog.DTOs.AppEntityPropertyChanges;

public class AppEntityPropertyChangeResponseDto : CreationAuditedEntityDto<Guid>
{
    public string? NewValue { get; set; } 
    public string? OriginalValue { get; set; }
    public string PropertyName { get; set; } = null!;
    public string PropertyTypeFullName { get; set; } = null!;
    
    public Guid AuditLogId { get; set; }
}