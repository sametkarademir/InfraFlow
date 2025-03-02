using InfraFlow.Core.Domain.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Core.Domain.Aggregates.AuditedAggregateRoots;

public interface IAuditedObject : 
    ICreationAuditedObject,
    IHasCreationTime,
    IMayHaveCreator,
    IModificationAuditedObject,
    IHasModificationTime
{
}