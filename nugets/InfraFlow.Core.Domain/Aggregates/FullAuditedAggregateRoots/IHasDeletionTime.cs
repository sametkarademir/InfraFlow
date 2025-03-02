namespace InfraFlow.Core.Domain.Aggregates.FullAuditedAggregateRoots;

public interface IHasDeletionTime : ISoftDelete
{
    DateTime? DeletionTime { get; set; }
}