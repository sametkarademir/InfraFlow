namespace InfraFlow.Core.Domain.Dtos;

public class FullAuditedEntityDto<TKey> : AuditedEntityDto<TKey>
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterId { get; set; }
}