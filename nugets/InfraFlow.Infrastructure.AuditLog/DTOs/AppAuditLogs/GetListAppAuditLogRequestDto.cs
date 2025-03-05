using InfraFlow.Domain.AuditLog.Enums;

namespace InfraFlow.Infrastructure.AuditLog.DTOs.AppAuditLogs;

public class GetListAppAuditLogRequestDto
{
    public Guid? CorrelationId { get; set; }
    public Guid? AppSnapshotId { get; set; }
    public Guid? SessionId { get; set; }
    
    public string? EntityId { get; set; }
    public string? EntityName { get; set; }
    public EntityState? EntityState { get; set; }
    
    public int Index { get; set; }
    public int Size { get; set; }
}