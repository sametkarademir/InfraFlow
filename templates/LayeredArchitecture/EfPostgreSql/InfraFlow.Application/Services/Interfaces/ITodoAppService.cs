using InfraFlow.Application.DTOs.Common;
using InfraFlow.Domain.Entities;
using InfraFlow.EntityFramework.Core.Models;

namespace InfraFlow.Application.Services.Interfaces;

public interface ITodoAppService
{
    Task<Todo> GetAsync(Guid id);
    Task<Paginate<Todo>> GetListAsync(PaginateRequestDto request);
    Task<Todo> CreateAsync(Todo todo);
    Task<Todo> UpdateAsync(Guid id, string name);
    Task DeleteAsync(Guid id);
    Task HardDeleteAsync(Guid id);
}