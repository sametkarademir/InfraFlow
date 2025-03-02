namespace InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

public interface IMayHaveCreator
{
    Guid? CreatorId { get; set; }
}