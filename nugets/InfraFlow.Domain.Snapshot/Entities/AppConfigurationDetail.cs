using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Snapshot.Entities;

[ExcludeFromProcessing]
public class AppConfigurationDetail : CreationAuditedAggregateRoot<Guid>
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}