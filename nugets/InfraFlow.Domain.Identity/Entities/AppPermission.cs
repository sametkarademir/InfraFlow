using InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppPermission : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Resource { get; set; } = null!;
    public string Action { get; set; } = null!;

    public List<AppRolePermission>? AppRolePermissions { get; set; }
}