using InfraFlow.Domain.Core.Aggregates.Entities;

namespace InfraFlow.Domain.Core.Dtos;

public abstract class EntityDto<TKey> : ICorrelationEntity, IAppSnapshotEntity, ISessionEntity
{
    public TKey Id { get; set; } = default!;
    public Guid? CorrelationId { get; set; }
    public Guid? AppSnapshotId { get; set; }
    public Guid? SessionId { get; set; }
}