using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public interface IAppUserRoleRepository : IRepository<AppUserRole, Guid>
{
    
}