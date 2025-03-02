namespace InfraFlow.Domain.Core.Aggregates.Entities;

public interface IEntity : ICorrelationEntity, IAppSnapshotEntity, ISessionEntity
{
}

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}