namespace InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}