using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.AuditLog.Repositories;

public class AppEntityPropertyChangeRepository<TContext> : EfRepositoryBase<AppEntityPropertyChange, Guid, TContext>, IAppEntityPropertyChangeRepository where TContext : DbContext
{
    public AppEntityPropertyChangeRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}