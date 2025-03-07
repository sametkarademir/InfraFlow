namespace InfraFlow.Core.Domain.Aggregates.Entities;

[Serializable]
public abstract class Entity : IEntity
{
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}]";
    }
}

[Serializable]
public abstract class Entity<TKey> : Entity, IEntity<TKey>
{
    public virtual TKey Id { get; set; } = default!;

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
