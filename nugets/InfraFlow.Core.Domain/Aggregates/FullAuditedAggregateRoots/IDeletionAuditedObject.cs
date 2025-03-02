namespace InfraFlow.Core.Domain.Aggregates.FullAuditedAggregateRoots;

public interface IDeletionAuditedObject : IHasDeletionTime, ISoftDelete
{
    Guid? DeleterId { get; set; }
}