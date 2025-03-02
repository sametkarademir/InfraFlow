using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Snapshot.Repositories;

public class AppDatabaseDetailRepository<TContext> : EfRepositoryBase<AppDatabaseDetail, Guid, TContext>, IAppDatabaseDetailRepository 
    where TContext : DbContext
{
    public AppDatabaseDetailRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}