using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppUserFailedLoginAttemptRepository<TContext> : EfRepositoryBase<AppUserFailedLoginAttempt, Guid, TContext>, IAppUserFailedLoginAttemptRepository where TContext : DbContext
{
    public AppUserFailedLoginAttemptRepository(TContext context) : base(context)
    {
        
    }
}