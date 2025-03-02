namespace InfraFlow.Core.Domain.Aggregates.AuditedAggregateRoots;

public interface IModificationAuditedObject : IHasModificationTime
{
    Guid? LastModifierId { get; set; }
}