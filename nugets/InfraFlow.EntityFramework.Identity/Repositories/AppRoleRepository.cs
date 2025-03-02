using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppRoleRepository<TContext> : EfRepositoryBase<AppRole, Guid, TContext>, IAppRoleRepository where TContext : DbContext
{
    public AppRoleRepository(TContext context) : base(context)
    {
        
    }
}