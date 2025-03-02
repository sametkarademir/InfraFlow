using InfraFlow.Domain.Core.Aggregates.CreationAuditedAggregateRoots;
using InfraFlow.Domain.Core.Filters;

namespace InfraFlow.Domain.Snapshot.Entities;

[ExcludeFromProcessing]
public class AppSnapshot : CreationAuditedAggregateRoot<Guid>
{
    public AppSnapshot()
    {
        Id = Guid.NewGuid();
    }
    
    public string? ApplicationName { get; set; }
    public string? ApplicationVersion { get; set; }
    public string? Environment { get; set; }
    public string? MachineName { get; set; }
    public string? MachineOsVersion { get; set; }
    public string? Platform { get; set; }
    public string? CultureInfo { get; set; }
    public string? CpuCoreCount { get; set; }
    public string? CpuArchitecture { get; set; }
    public string? TotalRam { get; set; }
    public string? TotalDiskSpace { get; set; }
    public string? InterfaceName { get; set; }
    public string? IpAddress { get; set; }
    public string? Hostname { get; set; }
}