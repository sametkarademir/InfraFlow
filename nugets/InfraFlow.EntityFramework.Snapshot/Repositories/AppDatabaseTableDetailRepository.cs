using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Snapshot.Repositories;

public class AppDatabaseTableDetailRepository<TContext> : EfRepositoryBase<AppDatabaseTableDetail, Guid, TContext>, IAppDatabaseTableDetailRepository 
    where TContext : DbContext
{
    public AppDatabaseTableDetailRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}