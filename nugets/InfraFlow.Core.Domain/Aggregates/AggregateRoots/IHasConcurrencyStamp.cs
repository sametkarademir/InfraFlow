namespace InfraFlow.Core.Domain.Aggregates.AggregateRoots;

public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}