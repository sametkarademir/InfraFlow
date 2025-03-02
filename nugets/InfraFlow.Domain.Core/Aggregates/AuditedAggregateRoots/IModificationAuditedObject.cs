namespace InfraFlow.Domain.Core.Aggregates.AuditedAggregateRoots;

public interface IModificationAuditedObject : IHasModificationTime
{
    Guid? LastModifierId { get; set; }
}