using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppUserSession : CreationAuditedAggregateRoot<Guid>
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime AccessTokenExpiredTime { get; set; }
    public DateTime RefreshTokenExpiredTime { get; set; }
    public bool AccessTokenIsExpired => DateTime.UtcNow >= AccessTokenExpiredTime;
    public bool RefreshTokenIsExpired => DateTime.UtcNow >= RefreshTokenExpiredTime;
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}