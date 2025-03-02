using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;

namespace InfraFlow.Domain.ExceptionLog.Entities;

public class AppExceptionLog : CreationAuditedAggregateRoot<Guid>
{
    public string? Type { get; set; }
    public string? Message { get; set; } 
    public string? Source { get; set; }
    public string? StackTrace { get; set; }
    public string? InnerException { get; set; }
    public string? ResponseBody { get; set; }
}