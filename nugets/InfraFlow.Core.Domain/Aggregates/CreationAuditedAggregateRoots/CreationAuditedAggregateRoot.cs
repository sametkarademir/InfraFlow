using InfraFlow.Core.Domain.Aggregates.AggregateRoots;
using InfraFlow.Core.Domain.Filters;

namespace InfraFlow.Core.Domain.Aggregates.CreationAuditedAggregateRoots;

[Serializable]
public abstract class CreationAuditedAggregateRoot<TKey> : AggregateRoot<TKey>, ICreationAuditedObject
{
    [ExcludeFromProcessing] public virtual DateTime CreationTime { get; set; }
    [ExcludeFromProcessing] public virtual Guid? CreatorId { get; set; }
    
    protected CreationAuditedAggregateRoot()
    {

    }

    protected CreationAuditedAggregateRoot(TKey id) : base(id)
    {

    }
}

[Serializable]
public abstract class CreationAuditedAggregateRoot : AggregateRoot, ICreationAuditedObject
{
    [ExcludeFromProcessing] public virtual DateTime CreationTime { get; set; }
    [ExcludeFromProcessing] public virtual Guid? CreatorId { get; set; }
}