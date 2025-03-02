namespace InfraFlow.Domain.Core.Aggregates.BasicAggregateRoots;

/// <summary>
/// Interface for generating domain events.
/// </summary>
public interface IGeneratesDomainEvents
{
    /// <summary>
    /// Gets the local domain events.
    /// </summary>
    /// <returns>A collection of local domain events.</returns>
    IEnumerable<DomainEventRecord> GetLocalEvents();

    /// <summary>
    /// Gets the distributed domain events.
    /// </summary>
    /// <returns>A collection of distributed domain events.</returns>
    IEnumerable<DomainEventRecord> GetDistributedEvents();

    /// <summary>
    /// Clears the local domain events.
    /// </summary>
    void ClearLocalEvents();

    /// <summary>
    /// Clears the distributed domain events.
    /// </summary>
    void ClearDistributedEvents();

    /// <summary>
    /// Adds a local domain event.
    /// </summary>
    /// <param name="eventData">The event data to add.</param>
    void AddLocalEvent(object eventData);

    /// <summary>
    /// Adds a distributed domain event.
    /// </summary>
    /// <param name="eventData">The event data to add.</param>
    void AddDistributedEvent(object eventData);
}