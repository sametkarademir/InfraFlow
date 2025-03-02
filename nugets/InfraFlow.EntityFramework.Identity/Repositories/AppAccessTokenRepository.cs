using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppAccessTokenRepository<TContext> : EfRepositoryBase<AppAccessToken, Guid, TContext>, IAppAccessTokenRepository where TContext : DbContext
{
    public AppAccessTokenRepository(TContext context) : base(context)
    {
        
    }
}