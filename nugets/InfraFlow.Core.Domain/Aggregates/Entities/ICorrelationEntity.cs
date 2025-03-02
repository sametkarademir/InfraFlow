namespace InfraFlow.Core.Domain.Aggregates.Entities;

public interface ICorrelationEntity
{
    public Guid? CorrelationId { get; set; }
}