using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppUserFailedLoginAttempt : CreationAuditedAggregateRoot<Guid>
{
    public string UserName { get; set; } = null!;
    public string FailureReason { get; set; } = null!;
    
    public Guid? AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}