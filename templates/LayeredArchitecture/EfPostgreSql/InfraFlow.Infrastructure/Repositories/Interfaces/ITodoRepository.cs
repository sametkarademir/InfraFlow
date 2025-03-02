using InfraFlow.Domain.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.Infrastructure.Repositories.Interfaces;

public interface ITodoRepository : IRepository<Todo, Guid>
{
    
}