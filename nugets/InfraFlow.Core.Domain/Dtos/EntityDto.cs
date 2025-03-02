namespace InfraFlow.Core.Domain.Dtos;

public abstract class EntityDto<TKey>
{
    public TKey Id { get; set; } = default!;
}