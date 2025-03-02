namespace InfraFlow.Core.Domain.Aggregates.AuditedAggregateRoots;

public interface IHasModificationTime
{
    DateTime? LastModificationTime { get; set; }
}