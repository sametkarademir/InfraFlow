namespace InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

public interface IHasCreationTime
{
    DateTime CreationTime { get; set; }
}