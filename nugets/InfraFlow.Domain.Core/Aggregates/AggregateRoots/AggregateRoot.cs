using InfraFlow.Domain.Core.Aggregates.BasicAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Core.Aggregates.AggregateRoots;

[Serializable]
public abstract class AggregateRoot : BasicAggregateRoot, IHasConcurrencyStamp, IHasExtraProperties
{
    [ExcludeFromProcessing] public virtual string ConcurrencyStamp { get; set; }
    [ExcludeFromProcessing] public virtual ExtraPropertyDictionary ExtraProperties { get; protected set; }
    
    protected AggregateRoot()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
        ExtraProperties = new ExtraPropertyDictionary();
    }
    
}

[Serializable]
public abstract class AggregateRoot<TKey> : BasicAggregateRoot<TKey>, IHasConcurrencyStamp, IHasExtraProperties
{
    [ExcludeFromProcessing] public virtual string ConcurrencyStamp { get; set; }
    [ExcludeFromProcessing] public virtual ExtraPropertyDictionary ExtraProperties { get; protected set; }

    protected AggregateRoot()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
        ExtraProperties = new ExtraPropertyDictionary();
    }

    protected AggregateRoot(TKey id)
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
        ExtraProperties = new ExtraPropertyDictionary();
    }
}