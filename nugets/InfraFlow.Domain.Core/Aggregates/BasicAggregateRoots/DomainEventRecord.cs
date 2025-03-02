namespace InfraFlow.Domain.Core.Aggregates.BasicAggregateRoots;

/// <summary>
/// Represents a record of a domain event.
/// </summary>
public class DomainEventRecord
{
    /// <summary>
    /// Gets the event data.
    /// </summary>
    public object EventData { get; }

    /// <summary>
    /// Gets the order of the event.
    /// </summary>
    public long EventOrder { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEventRecord"/> class.
    /// </summary>
    /// <param name="eventData">The data associated with the event.</param>
    /// <param name="eventOrder">The order of the event.</param>
    public DomainEventRecord(object eventData, long eventOrder)
    {
        EventData = eventData;
        EventOrder = eventOrder;
    }
}