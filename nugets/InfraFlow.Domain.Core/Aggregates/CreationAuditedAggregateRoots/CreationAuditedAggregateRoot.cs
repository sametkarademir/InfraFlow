using InfraFlow.Domain.Core.Aggregates.AggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

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