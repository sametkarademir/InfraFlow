namespace InfraFlow.Core.Domain.Aggregates.FullAuditedAggregateRoots;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}