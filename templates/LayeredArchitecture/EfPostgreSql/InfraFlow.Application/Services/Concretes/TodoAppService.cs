using InfraFlow.Application.DTOs.Common;
using InfraFlow.Application.Services.Interfaces;
using InfraFlow.Domain.Entities;
using InfraFlow.EntityFramework.Core.Models;
using InfraFlow.Infrastructure.Repositories.Interfaces;

namespace InfraFlow.Application.Services.Concretes;

public class TodoAppService(ITodoRepository todoRepository) : ITodoAppService
{
    public async Task<Todo> GetAsync(Guid id)
    {
        var todo = await todoRepository.GetAsync(item => item.Id == id);
        
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }
        
        return todo;
    }

    public async Task<Paginate<Todo>> GetListAsync(PaginateRequestDto request)
    {
        var todos = await todoRepository.GetListAsync(index: request.PageIndex, size: request.PageSize);
        
        return todos;
    }

    public async Task<Todo> CreateAsync(Todo todo)
    {
        todo.Id = Guid.NewGuid();
        todo = await todoRepository.AddAsync(todo, true);
        
        return todo;
    }

    public async Task<Todo> UpdateAsync(Guid id, string name)
    {
        var todo = await this.GetAsync(id);
        todo.Name = name;
        todo = await todoRepository.UpdateAsync(todo, true);
        
        return todo;
    }

    public async Task DeleteAsync(Guid id)
    {
        var todo = await this.GetAsync(id);
        await todoRepository.DeleteAsync(todo, false, true);
    }

    public async Task HardDeleteAsync(Guid id)
    {
        var todo = await todoRepository.GetAsync(item => item.Id == id, withDeleted: true);
        
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }
        
        await todoRepository.DeleteAsync(todo,true, true);
    }
}