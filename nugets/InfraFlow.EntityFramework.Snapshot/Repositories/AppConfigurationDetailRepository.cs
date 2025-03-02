using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Snapshot.Repositories;

public class AppConfigurationDetailRepository<TContext> : EfRepositoryBase<AppConfigurationDetail, Guid, TContext>, IAppConfigurationDetailRepository 
    where TContext : DbContext
{
    public AppConfigurationDetailRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}