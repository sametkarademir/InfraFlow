using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.AuditLog.Entities;

[ExcludeFromProcessing]
public class AppEntityPropertyChange : CreationAuditedAggregateRoot<Guid>
{
    public string? NewValue { get; set; } 
    public string? OriginalValue { get; set; }
    public string PropertyName { get; set; } = null!;
    public string PropertyTypeFullName { get; set; } = null!;
    
    public Guid AuditLogId { get; set; }
}