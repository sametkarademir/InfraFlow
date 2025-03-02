using InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;
using InfraFlow.Domain.Identity.Enums;

namespace InfraFlow.Domain.Identity.Entities;

public class AppVerificationCode : FullAuditedAggregateRoot<Guid>
{
    public string Code { get; set; } = null!;
    public VerificationTypes VerificationType { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsUsed { get; set; }
    public DateTime? UsedAt { get; set; }
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}