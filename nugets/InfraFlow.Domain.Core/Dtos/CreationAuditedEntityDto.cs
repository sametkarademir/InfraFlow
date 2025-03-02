namespace InfraFlow.Domain.Core.Dtos;

public abstract class CreationAuditedEntityDto<TKey> : EntityDto<TKey>
{
    public DateTime CreationTime { get; set; }
    public Guid? CreatorId { get; set; }
}