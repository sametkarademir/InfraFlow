using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Snapshot.Repositories;

public class AppSnapshotRepository<TContext> : EfRepositoryBase<AppSnapshot, Guid, TContext>, IAppSnapshotRepository 
    where TContext : DbContext
{
    public AppSnapshotRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}