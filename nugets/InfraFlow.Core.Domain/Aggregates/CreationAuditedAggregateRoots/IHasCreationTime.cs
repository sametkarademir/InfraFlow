namespace InfraFlow.Core.Domain.Aggregates.CreationAuditedAggregateRoots;

public interface IHasCreationTime
{
    DateTime CreationTime { get; set; }
}