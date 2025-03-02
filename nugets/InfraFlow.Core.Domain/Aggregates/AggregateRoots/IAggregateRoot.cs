using InfraFlow.Core.Domain.Aggregates.Entities;

namespace InfraFlow.Core.Domain.Aggregates.AggregateRoots
{
    public interface IAggregateRoot : IEntity
    {
    
    }

    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    {
    }
}