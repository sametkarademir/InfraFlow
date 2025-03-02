using InfraFlow.Domain.AuditLog.Enums;
using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.AuditLog.Entities;

[ExcludeFromProcessing]
public class AppAuditLog : CreationAuditedAggregateRoot<Guid>
{
    public AppAuditLog()
    {
        Id = Guid.NewGuid();
    }
    
    public string EntityId { get; set; } = null!;
    public string EntityName { get; set; } = null!;
    public EntityState EntityState { get; set; }
    
    public ICollection<AppEntityPropertyChange>? AppEntityPropertyChanges { get; set; }
}