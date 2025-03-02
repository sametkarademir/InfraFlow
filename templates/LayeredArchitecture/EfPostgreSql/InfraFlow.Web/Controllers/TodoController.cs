using InfraFlow.Application.DTOs.Common;
using InfraFlow.Application.Services.Interfaces;
using InfraFlow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InfraFlow.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoAppService _todoAppService;

    public TodoController(ITodoAppService todoAppService)
    {
        _todoAppService = todoAppService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] Guid id)
    {
        var todo = await _todoAppService.GetAsync(id);
        
        return Ok(todo);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] PaginateRequestDto request)
    {
        var todos = await _todoAppService.GetListAsync(request);
        
        return Ok(todos);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Todo createTodoDto)
    {
        var todo = await _todoAppService.CreateAsync(createTodoDto);
        
        return Ok(todo);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] Guid id, [FromQuery] string name)
    {
        var todo = await _todoAppService.UpdateAsync(id, name);
        
        return Ok(todo);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] Guid id)
    {
        await _todoAppService.DeleteAsync(id);
        
        return Ok();
    }
    
    [HttpDelete("hard-delete/{id}")]
    public async Task<IActionResult> HardDeleteAsync([FromRoute(Name = "id")] Guid id)
    {
        await _todoAppService.HardDeleteAsync(id);
        
        return Ok();
    }
    
}