using InfraFlow.Domain.HttpRequestLog.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.HttpRequestLog.Repositories;

public interface IAppHttpRequestLogRepository : IRepository<AppHttpRequestLog, Guid>
{
    
}