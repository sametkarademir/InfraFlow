using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppRefreshToken : CreationAuditedAggregateRoot<Guid>
{
    public string Token { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public string? ReplacedByToken { get; set; }
    public DateTime? RevokedAt { get; set; }
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}