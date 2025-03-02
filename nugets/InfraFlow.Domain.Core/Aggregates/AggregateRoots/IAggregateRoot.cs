using InfraFlow.Domain.Core.Aggregates.Entities;

namespace InfraFlow.Domain.Core.Aggregates.AggregateRoots
{
    public interface IAggregateRoot : IEntity
    {
    
    }

    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    {
    }
}