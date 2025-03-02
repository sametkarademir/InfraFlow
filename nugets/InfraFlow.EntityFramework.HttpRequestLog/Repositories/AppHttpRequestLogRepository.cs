using InfraFlow.Domain.HttpRequestLog.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.HttpRequestLog.Repositories;

public class AppHttpRequestLogRepository<TContext> : EfRepositoryBase<AppHttpRequestLog, Guid, TContext>, IAppHttpRequestLogRepository 
    where TContext : DbContext
{
    public AppHttpRequestLogRepository(TContext dbContext) : base(dbContext)
    {
        
    }
}