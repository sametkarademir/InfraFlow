using InfraFlow.Domain.Core.Dtos;

namespace InfraFlow.Infrastructure.Snapshot.DTOs.AppAssemblies;

public class AppAssemblyResponseDto : CreationAuditedEntityDto<Guid>
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? Culture { get; set; }
    public string? PublicKeyToken { get; set; }
    public string? Location { get; set; }
}