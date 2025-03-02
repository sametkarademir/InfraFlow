using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppUserRoleRepository<TContext> : EfRepositoryBase<AppUserRole, Guid, TContext>, IAppUserRoleRepository where TContext : DbContext
{
    public AppUserRoleRepository(TContext context) : base(context)
    {
        
    }
}