using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.AuditLog.Repositories;

public class AppAuditLogRepository<TContext> : EfRepositoryBase<AppAuditLog, Guid, TContext>, IAppAuditLogRepository where TContext : DbContext
{
    public AppAuditLogRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}