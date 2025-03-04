using Microsoft.AspNetCore.Builder;

namespace InfraFlow.Infrastructure.Snapshot.DependencyInjection;

public static class ApplicationBuilderExceptionMiddlewareExtensions
{
    public static void ConfigureSnapshotMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ProgressingStartedMiddleware>();
    }
}
