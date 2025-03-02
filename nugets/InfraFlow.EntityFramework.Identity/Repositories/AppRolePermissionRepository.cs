using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppRolePermissionRepository<TContext> : EfRepositoryBase<AppRolePermission, Guid, TContext>, IAppRolePermissionRepository where TContext : DbContext
{
    public AppRolePermissionRepository(TContext context) : base(context)
    {
        
    }
}