using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppAccessToken : CreationAuditedAggregateRoot<Guid>
{
    public string Token { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    
    public bool IsRevoked { get; set; }
    public DateTime? RevokedAt { get; set; }
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}