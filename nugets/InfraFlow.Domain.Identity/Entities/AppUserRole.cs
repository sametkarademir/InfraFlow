using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppUserRole : CreationAuditedAggregateRoot<Guid>
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
    public Guid AppRoleId { get; set; }
    public AppRole? AppRole { get; set; }
}