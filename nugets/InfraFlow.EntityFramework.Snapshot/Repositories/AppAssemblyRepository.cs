using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Snapshot.Repositories;

public class AppAssemblyRepository<TContext> : EfRepositoryBase<AppAssembly, Guid, TContext>, IAppAssemblyRepository 
    where TContext : DbContext
{
    public AppAssemblyRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}