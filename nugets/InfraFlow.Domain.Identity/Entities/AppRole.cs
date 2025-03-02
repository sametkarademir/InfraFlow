using InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppRole : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = null!;
    public string NormalizedName { get; set; } = null!;
    public string? Description { get; set; }

    public List<AppUserRole>? AppUserRoles { get; set; }
    public List<AppRolePermission>? AppRolePermissions { get; set; }
}