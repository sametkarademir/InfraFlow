namespace InfraFlow.Domain.Core.Aggregates.AggregateRoots;

public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}