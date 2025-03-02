using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.HttpRequestLog.Entities;

[ExcludeFromProcessing]
public class AppHttpRequestLog : CreationAuditedAggregateRoot<Guid>
{
    public string? User { get; set; }
    
    public string? ClientIpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Device { get; set; }
    public string? DeviceOs { get; set; }
    public string? BrowserInfo { get; set; }
    public string? ServiceName { get; set; }
    public string? MethodName { get; set; }
    public string? HttpMethod { get; set; }
    public string? RequestUrl { get; set; }
    public string? ResponseStatus { get; set; }
    public DateTime? ExecutionTime { get; set; }
    public string? ExecutionDuration { get; set; }
    public string? RequestHeaders { get; set; }
    public string? RequestQuery { get; set; }
    public string? RequestBody { get; set; }
}