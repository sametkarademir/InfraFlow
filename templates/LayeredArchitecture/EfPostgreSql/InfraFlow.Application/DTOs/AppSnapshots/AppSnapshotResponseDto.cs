using InfraFlow.Domain.Core.Dtos;

namespace InfraFlow.Application.DTOs.AppSnapshots;

public class AppSnapshotResponseDto : CreationAuditedEntityDto<Guid>
{
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
    public string? Hostname { get; set; }
    
    public List<string>? InterfaceNames { get; set; }
    public List<string>? IpAddresses { get; set; }
}