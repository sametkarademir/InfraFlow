using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppPermissionRepository<TContext> : EfRepositoryBase<AppPermission, Guid, TContext>, IAppPermissionRepository where TContext : DbContext
{
    public AppPermissionRepository(TContext context) : base(context)
    {
        
    }
}