using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Core.Aggregates.Entities;

[Serializable]
public abstract class Entity : IEntity
{
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}]";
    }

    [ExcludeFromProcessing] public Guid? CorrelationId { get; set; }
    [ExcludeFromProcessing] public Guid? AppSnapshotId { get; set; }
    [ExcludeFromProcessing] public Guid? SessionId { get; set; }
}

[Serializable]
public abstract class Entity<TKey> : Entity, IEntity<TKey>
{
    [ExcludeFromProcessing] public virtual TKey Id { get; set; } = default!;

    protected Entity()
    {

    }

    protected Entity(TKey id)
    {
        Id = id;
    }
    
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Id = {Id}";
    }
}
