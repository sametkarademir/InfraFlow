using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppUserRepository<TContext> : EfRepositoryBase<AppUser, Guid, TContext>, IAppUserRepository where TContext : DbContext
{
    public AppUserRepository(TContext context) : base(context)
    {
        
    }
}