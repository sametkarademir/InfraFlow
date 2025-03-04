using InfraFlow.Application.DTOs.Common;
using InfraFlow.Infrastructure.Snapshot.Services.AppSnapshots;
using Microsoft.AspNetCore.Mvc;

namespace InfraFlow.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppSnapshotController : ControllerBase
{
    private readonly IAppSnapshotAppService _appSnapshotService;

    public AppSnapshotController(IAppSnapshotAppService appSnapshotService)
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
        var snapshots = await _appSnapshotService.GetSnapshotsPaginatedAsync(request.PageIndex, request.PageSize);
        
        return Ok(snapshots);
    }
    
}