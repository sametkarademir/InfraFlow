using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.Snapshot.Repositories;

public interface IAppSnapshotRepository : IRepository<AppSnapshot, Guid>
{
    
}