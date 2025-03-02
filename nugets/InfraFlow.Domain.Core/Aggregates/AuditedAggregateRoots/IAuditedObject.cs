using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Core.Aggregates.AuditedAggregateRoots;

public interface IAuditedObject : 
    ICreationAuditedObject,
    IHasCreationTime,
    IMayHaveCreator,
    IModificationAuditedObject,
    IHasModificationTime
{
}