using InfraFlow.Domain.Core.Aggregates.AuditedAggregateRoots;
using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

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