namespace InfraFlow.Core.Domain.Aggregates.CreationAuditedAggregateRoots;

public interface ICreationAuditedObject : IHasCreationTime, IMayHaveCreator
{
}