using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Snapshot.Entities;

[ExcludeFromProcessing]
public class AppDatabaseTableDetail : CreationAuditedAggregateRoot<Guid>
{
    public string? TableName { get; set; }
    public long RecordCount { get; set; }

    public Guid AppDatabaseDetailId { get; set; }
}