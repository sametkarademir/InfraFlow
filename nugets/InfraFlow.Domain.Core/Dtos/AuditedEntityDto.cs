namespace InfraFlow.Domain.Core.Dtos;

public class AuditedEntityDto<TKey> : CreationAuditedEntityDto<TKey>
{
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierId { get; set; }
}