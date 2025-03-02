using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppRefreshTokenRepository<TContext> : EfRepositoryBase<AppRefreshToken, Guid, TContext>, IAppRefreshTokenRepository where TContext : DbContext
{
    public AppRefreshTokenRepository(TContext context) : base(context)
    {
        
    }
}