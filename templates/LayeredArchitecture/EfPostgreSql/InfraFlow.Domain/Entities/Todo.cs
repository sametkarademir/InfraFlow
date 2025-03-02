using InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

namespace InfraFlow.Domain.Entities;

public class Todo : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = null!;
}