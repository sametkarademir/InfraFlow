using InfraFlow.Domain.Core.Dtos;

namespace InfraFlow.Infrastructure.Snapshot.DTOs.AppConfigurationDetails;

public class AppConfigurationDetailResponseDto : CreationAuditedEntityDto<Guid>
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}