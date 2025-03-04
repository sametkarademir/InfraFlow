using InfraFlow.Domain.Core.Dtos;
using InfraFlow.Infrastructure.Snapshot.DTOs.AppDatabaseTableDetails;

namespace InfraFlow.Infrastructure.Snapshot.DTOs.AppDatabaseDetails;

public class AppDatabaseDetailResponseDto : CreationAuditedEntityDto<Guid>
{
    public string? Host { get; set; }
    public string? DatabaseName { get; set; }
    public string? DatabaseVersion { get; set; }
    public int TableCount { get; set; }

    public List<AppDatabaseTableDetailResponseDto>? AppDatabaseTableDetails { get; set; }
}