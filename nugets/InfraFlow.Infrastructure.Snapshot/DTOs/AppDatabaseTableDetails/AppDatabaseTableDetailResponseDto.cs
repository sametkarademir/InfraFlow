using InfraFlow.Domain.Core.Dtos;

namespace InfraFlow.Infrastructure.Snapshot.DTOs.AppDatabaseTableDetails;

public class AppDatabaseTableDetailResponseDto : CreationAuditedEntityDto<Guid>
{
    public string? TableName { get; set; }
    public long RecordCount { get; set; }

    public Guid AppDatabaseDetailId { get; set; }
}