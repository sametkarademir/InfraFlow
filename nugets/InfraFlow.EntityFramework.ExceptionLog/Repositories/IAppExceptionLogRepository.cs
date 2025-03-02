using InfraFlow.Domain.ExceptionLog.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.ExceptionLog.Repositories;

public interface IAppExceptionLogRepository : IRepository<AppExceptionLog, Guid>
{
    
}