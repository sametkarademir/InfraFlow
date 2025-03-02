using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.AuditLog.Repositories;

public interface IAppEntityPropertyChangeRepository : IRepository<AppEntityPropertyChange, Guid>
{
    
}