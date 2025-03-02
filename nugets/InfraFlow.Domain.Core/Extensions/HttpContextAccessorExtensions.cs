using Microsoft.AspNetCore.Http;

namespace InfraFlow.Domain.Core.Extensions;

public static class HttpContextAccessorExtensions
{
    public static Guid? GetCorrelationId(this HttpRequest request)
        => request.Headers["X-Correlation-ID"].FirstOrDefault() != null ? Guid.Parse(request.Headers["X-Correlation-ID"].FirstOrDefault()!) : null;

    public static Guid? GetSnapshotId(this HttpRequest request)
        => request.Headers["X-Snapshot-ID"].FirstOrDefault() != null ? Guid.Parse(request.Headers["X-Snapshot-ID"].FirstOrDefault()!) : null;
    
    public static Guid? GetSessionId(this HttpRequest request) 
        => request.Headers["X-Session-ID"].FirstOrDefault() != null ? Guid.Parse(request.Headers["X-Session-ID"].FirstOrDefault()!) : null;
    
    public static void SetCorrelationId(this HttpRequest request, Guid correlationId)
        => request.Headers.Append("X-Correlation-ID", correlationId.ToString());
    
    public static void SetSnapshotId(this HttpRequest request, Guid snapshotId) 
        => request.Headers.Append("X-Snapshot-ID", snapshotId.ToString());
    
    public static void SetSessionId(this HttpRequest request, Guid sessionId) 
        => request.Headers.Append("X-Session-ID", sessionId.ToString());
}