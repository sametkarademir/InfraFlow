namespace InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

public interface ICreationAuditedObject : IHasCreationTime, IMayHaveCreator
{
}