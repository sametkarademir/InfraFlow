using InfraFlow.Domain.Core.Extensions;
using InfraFlow.Infrastructure.Snapshot.Services.AppSnapshots;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace InfraFlow.Infrastructure.Snapshot.DependencyInjection;

public class ProgressingStartedMiddleware(RequestDelegate next, ILogger<ProgressingStartedMiddleware> logger, IAppSnapshotAppService appSnapshotAppService)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            context.Request.SetSnapshotId(await appSnapshotAppService.GetLatestAppSnapshotIdAsync());
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while setting snapshot id");
        }
        
        await next(context);
    }
}