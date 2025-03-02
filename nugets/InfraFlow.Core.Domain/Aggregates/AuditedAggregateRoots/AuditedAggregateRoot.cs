using InfraFlow.Core.Domain.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Core.Domain.Filters;

namespace InfraFlow.Core.Domain.Aggregates.AuditedAggregateRoots;

[Serializable]
public abstract class AuditedAggregateRoot : CreationAuditedAggregateRoot, IAuditedObject
{
    [ExcludeFromProcessing] public virtual DateTime? LastModificationTime { get; set; }
    [ExcludeFromProcessing] public virtual Guid? LastModifierId { get; set; }
}

[Serializable]
public abstract class AuditedAggregateRoot<TKey> : CreationAuditedAggregateRoot<TKey>, IAuditedObject
{
    [ExcludeFromProcessing] public virtual DateTime? LastModificationTime { get; set; }
    [ExcludeFromProcessing] public virtual Guid? LastModifierId { get; set; }

    protected AuditedAggregateRoot()
    {

    }

    protected AuditedAggregateRoot(TKey id) : base(id)
    {

    }
}