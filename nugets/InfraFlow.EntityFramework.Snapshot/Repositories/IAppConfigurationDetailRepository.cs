using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.Snapshot.Repositories;

public interface IAppConfigurationDetailRepository : IRepository<AppConfigurationDetail, Guid>
{
    
}