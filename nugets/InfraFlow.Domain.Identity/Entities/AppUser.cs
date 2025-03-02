using InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppUser : FullAuditedAggregateRoot<Guid>
{
    public string UserName { get; set; } = null!;
    public string NormalizedUserName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    public string NormalizedEmail { get; set; } = null!;
    public bool EmailVerified { get; set; }
    
    public string PasswordHash { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public string SecurityStamp { get; set; } = null!;
    public DateTime? PasswordChangedTime { get; set; }

    public string? PhoneNumber { get; set; }
    public bool PhoneVerified { get; set; }
    
    public bool IsActive { get; set; }

    public bool TwoFactorEnabled { get; set; }
    public string? TwoFactorSecret { get; set; }
    
    public DateTimeOffset? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }

    public AppUserProfile AppUserProfile { get; set; } = null!;
    
    public List<AppUserRole>? AppUserRoles { get; set; }
}