namespace InfraFlow.Core.Domain.Aggregates.Entities;

/// <summary>
/// Base interface for all entities.
/// </summary>
public interface IEntity
{
}

/// <summary>
/// Generic interface for entities with a specific key type.
/// </summary>
/// <typeparam name="TKey">The type of the entity's identifier.</typeparam>
public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}