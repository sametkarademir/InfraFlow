using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppUserSessionRepository<TContext> : EfRepositoryBase<AppUserSession, Guid, TContext>, IAppUserSessionRepository where TContext : DbContext
{
    public AppUserSessionRepository(TContext context) : base(context)
    {
        
    }
}