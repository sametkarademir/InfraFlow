using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppUserProfileRepository<TContext> : EfRepositoryBase<AppUserProfile, Guid, TContext>, IAppUserProfileRepository where TContext : DbContext
{
    public AppUserProfileRepository(TContext context) : base(context)
    {
        
    }
}