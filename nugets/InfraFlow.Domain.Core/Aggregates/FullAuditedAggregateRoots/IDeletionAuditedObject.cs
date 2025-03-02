namespace InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

public interface IDeletionAuditedObject : IHasDeletionTime, ISoftDelete
{
    Guid? DeleterId { get; set; }
}