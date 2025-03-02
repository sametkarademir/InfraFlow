using InfraFlow.Domain.Core.Aggregates.AuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

[Serializable]
public abstract class FullAuditedAggregateRoot : AuditedAggregateRoot, IFullAuditedObject
{
    public virtual bool IsDeleted { get; set; }
    
    [ExcludeFromProcessing] public virtual Guid? DeleterId { get; set; }
    
    [ExcludeFromProcessing] public virtual DateTime? DeletionTime { get; set; }
}

[Serializable]
public abstract class FullAuditedAggregateRoot<TKey> : AuditedAggregateRoot<TKey>, IFullAuditedObject
{
    public virtual bool IsDeleted { get; set; }

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
