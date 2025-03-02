namespace InfraFlow.Domain.Core.Aggregates.AuditedAggregateRoots;

public interface IHasModificationTime
{
    DateTime? LastModificationTime { get; set; }
}