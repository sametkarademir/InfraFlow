using InfraFlow.Domain.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using InfraFlow.Infrastructure.Contexts;
using InfraFlow.Infrastructure.Repositories.Interfaces;

namespace InfraFlow.Infrastructure.Repositories.Concretes;

public class TodoRepository : EfRepositoryBase<Todo, Guid, ApplicationDbContext>, ITodoRepository
{
    public TodoRepository(ApplicationDbContext context) : base(context)
    {
        
    }
}