using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.AuditLog.Repositories;

public interface IAppAuditLogRepository : IRepository<AppAuditLog, Guid>
{
    
}