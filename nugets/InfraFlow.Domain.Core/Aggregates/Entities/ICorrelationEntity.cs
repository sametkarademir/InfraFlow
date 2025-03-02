namespace InfraFlow.Domain.Core.Aggregates.Entities;

public interface ICorrelationEntity
{
    public Guid? CorrelationId { get; set; }
}