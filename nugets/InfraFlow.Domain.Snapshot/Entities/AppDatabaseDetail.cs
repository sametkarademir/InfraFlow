using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Snapshot.Entities;

[ExcludeFromProcessing]
public class AppDatabaseDetail : CreationAuditedAggregateRoot<Guid>
{
    public AppDatabaseDetail()
    {
        Id = Guid.NewGuid();
    }
    
    public string? Host { get; set; }
    public string? DatabaseName { get; set; }
    public string? DatabaseVersion { get; set; }
    public int TableCount { get; set; }

    public ICollection<AppDatabaseTableDetail>? AppDatabaseTableDetails { get; set; }
}