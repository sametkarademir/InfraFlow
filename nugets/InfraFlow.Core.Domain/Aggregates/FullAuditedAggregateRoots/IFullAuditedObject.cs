using InfraFlow.Core.Domain.Aggregates.AuditedAggregateRoots;
using InfraFlow.Core.Domain.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Core.Domain.Aggregates.FullAuditedAggregateRoots;

public interface IFullAuditedObject : 
    IAuditedObject,
    ICreationAuditedObject,
    IHasCreationTime,
    IMayHaveCreator,
    IModificationAuditedObject,
    IHasModificationTime,
    IDeletionAuditedObject,
    IHasDeletionTime,
    ISoftDelete
{
}