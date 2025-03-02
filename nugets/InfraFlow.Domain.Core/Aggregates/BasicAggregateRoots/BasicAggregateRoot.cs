using System.Collections.ObjectModel;
using InfraFlow.Domain.Core.Aggregates.AggregateRoots;
using InfraFlow.Domain.Core.Aggregates.Entities;

namespace InfraFlow.Domain.Core.Aggregates.BasicAggregateRoots;

/// <summary>
/// Represents a basic aggregate root that generates domain events.
/// </summary>
[Serializable]
public abstract class BasicAggregateRoot : Entity, IAggregateRoot, IGeneratesDomainEvents
{
    private readonly ICollection<DomainEventRecord> _distributedEvents = new Collection<DomainEventRecord>();
    private readonly ICollection<DomainEventRecord> _localEvents = new Collection<DomainEventRecord>();

    /// <summary>
    /// Gets the local domain events.
    /// </summary>
    /// <returns>A collection of local domain events.</returns>
    public virtual IEnumerable<DomainEventRecord> GetLocalEvents()
    {
        return _localEvents;
    }

    /// <summary>
    /// Gets the distributed domain events.
    /// </summary>
    /// <returns>A collection of distributed domain events.</returns>
    public virtual IEnumerable<DomainEventRecord> GetDistributedEvents()
    {
        return _distributedEvents;
    }

    /// <summary>
    /// Clears the local domain events.
    /// </summary>
    public virtual void ClearLocalEvents()
    {
        _localEvents.Clear();
    }

    /// <summary>
    /// Clears the distributed domain events.
    /// </summary>
    public virtual void ClearDistributedEvents()
    {
        _distributedEvents.Clear();
    }

    /// <summary>
    /// Adds a local domain event.
    /// </summary>
    /// <param name="eventData">The data associated with the event.</param>
    public virtual void AddLocalEvent(object eventData)
    {
        _localEvents.Add(new DomainEventRecord(eventData, EventOrderGeneratorExtensions.GetNext()));
    }

    /// <summary>
    /// Adds a distributed domain event.
    /// </summary>
    /// <param name="eventData">The data associated with the event.</param>
    public virtual void AddDistributedEvent(object eventData)
    {
        _distributedEvents.Add(new DomainEventRecord(eventData, EventOrderGeneratorExtensions.GetNext()));
    }
}

/// <summary>
/// Represents a basic aggregate root with a specific key type that generates domain events.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
[Serializable]
public abstract class BasicAggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>, IGeneratesDomainEvents
{
    private readonly ICollection<DomainEventRecord> _distributedEvents = new Collection<DomainEventRecord>();
    private readonly ICollection<DomainEventRecord> _localEvents = new Collection<DomainEventRecord>();

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicAggregateRoot{TKey}"/> class.
    /// </summary>
    protected BasicAggregateRoot()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicAggregateRoot{TKey}"/> class with the specified key.
    /// </summary>
    /// <param name="id">The key of the aggregate root.</param>
    protected BasicAggregateRoot(TKey id)
        : base(id)
    {
    }

    /// <summary>
    /// Gets the local domain events.
    /// </summary>
    /// <returns>A collection of local domain events.</returns>
    public virtual IEnumerable<DomainEventRecord> GetLocalEvents()
    {
        return _localEvents;
    }

    /// <summary>
    /// Gets the distributed domain events.
    /// </summary>
    /// <returns>A collection of distributed domain events.</returns>
    public virtual IEnumerable<DomainEventRecord> GetDistributedEvents()
    {
        return _distributedEvents;
    }

    /// <summary>
    /// Clears the local domain events.
    /// </summary>
    public virtual void ClearLocalEvents()
    {
        _localEvents.Clear();
    }

    /// <summary>
    /// Clears the distributed domain events.
    /// </summary>
    public virtual void ClearDistributedEvents()
    {
        _distributedEvents.Clear();
    }

    /// <summary>
    /// Adds a local domain event.
    /// </summary>
    /// <param name="eventData">The data associated with the event.</param>
    public virtual void AddLocalEvent(object eventData)
    {
        _localEvents.Add(new DomainEventRecord(eventData, EventOrderGeneratorExtensions.GetNext()));
    }

    /// <summary>
    /// Adds a distributed domain event.
    /// </summary>
    /// <param name="eventData">The data associated with the event.</param>
    public virtual void AddDistributedEvent(object eventData)
    {
        _distributedEvents.Add(new DomainEventRecord(eventData, EventOrderGeneratorExtensions.GetNext()));
    }
}

public static class EventOrderGeneratorExtensions
{
    private static long _lastOrder;

    public static long GetNext()
    {
        return Interlocked.Increment(ref _lastOrder);
    }
}