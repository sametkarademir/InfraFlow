using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppRolePermission : CreationAuditedAggregateRoot<Guid>
{
    public Guid AppRoleId { get; set; }
    public AppRole? AppRole { get; set; }
    
    public Guid AppPermissionId { get; set; }
    public AppPermission? AppPermission { get; set; }
}