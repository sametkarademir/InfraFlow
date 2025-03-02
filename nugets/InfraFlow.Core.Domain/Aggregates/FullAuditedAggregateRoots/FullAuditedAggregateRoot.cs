using InfraFlow.Core.Domain.Aggregates.AuditedAggregateRoots;
using InfraFlow.Core.Domain.Filters;

namespace InfraFlow.Core.Domain.Aggregates.FullAuditedAggregateRoots;

[Serializable]
public abstract class FullAuditedAggregateRoot : AuditedAggregateRoot, IFullAuditedObject
{
    [ExcludeFromProcessing] public virtual bool IsDeleted { get; set; }
    
    [ExcludeFromProcessing] public virtual Guid? DeleterId { get; set; }
    
    [ExcludeFromProcessing] public virtual DateTime? DeletionTime { get; set; }
}

[Serializable]
public abstract class FullAuditedAggregateRoot<TKey> : AuditedAggregateRoot<TKey>, IFullAuditedObject
{
    [ExcludeFromProcessing] public virtual bool IsDeleted { get; set; }

    [ExcludeFromProcessing] public virtual Guid? DeleterId { get; set; }

    [ExcludeFromProcessing] public virtual DateTime? DeletionTime { get; set; }
    
    protected FullAuditedAggregateRoot()
    {

    }

    protected FullAuditedAggregateRoot(TKey id)
        : base(id)
    {

    }
}
