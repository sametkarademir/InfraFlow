namespace InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

public interface IHasDeletionTime : ISoftDelete
{
    DateTime? DeletionTime { get; set; }
}