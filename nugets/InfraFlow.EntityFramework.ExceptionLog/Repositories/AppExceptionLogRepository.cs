using InfraFlow.Domain.ExceptionLog.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.ExceptionLog.Repositories;

public class AppExceptionLogRepository<TContext> : EfRepositoryBase<AppExceptionLog, Guid, TContext>, IAppExceptionLogRepository
    where TContext : DbContext
{
    public AppExceptionLogRepository(TContext dbContext) : base(dbContext)
    {
    }
}