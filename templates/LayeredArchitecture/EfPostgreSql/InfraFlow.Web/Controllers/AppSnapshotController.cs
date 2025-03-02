using InfraFlow.Application.DTOs.Common;
using InfraFlow.Application.Services.Interfaces.Snapshots;
using Microsoft.AspNetCore.Mvc;

namespace InfraFlow.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppSnapshotController : ControllerBase
{
    private readonly IAppSnapshotService _appSnapshotService;

    public AppSnapshotController(IAppSnapshotService appSnapshotService)
    {
        _appSnapshotService = appSnapshotService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSnapshotByIdAsync([FromRoute(Name = "id")] Guid id)
    {
        var snapshot = await _appSnapshotService.GetSnapshotByIdAsync(id);
        
        return Ok(snapshot);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSnapshotsPaginatedAsync([FromQuery] PaginateRequestDto request)
    {
        var snapshots = await _appSnapshotService.GetSnapshotsPaginatedAsync(request);
        
        return Ok(snapshots);
    }
    
}