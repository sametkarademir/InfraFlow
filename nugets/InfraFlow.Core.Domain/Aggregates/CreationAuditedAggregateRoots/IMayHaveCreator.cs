namespace InfraFlow.Core.Domain.Aggregates.CreationAuditedAggregateRoots;

public interface IMayHaveCreator
{
    Guid? CreatorId { get; set; }
}