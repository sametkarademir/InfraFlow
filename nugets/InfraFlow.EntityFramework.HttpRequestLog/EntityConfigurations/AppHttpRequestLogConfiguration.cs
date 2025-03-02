using InfraFlow.Domain.HttpRequestLog.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.HttpRequestLog.EntityConfigurations;

public class AppHttpRequestLogConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppHttpRequestLog>
{
    public void Configure(EntityTypeBuilder<AppHttpRequestLog> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppHttpRequestLogs");
        
        builder.Property(item => item.User).IsRequired(false);

        builder.Property(item => item.ClientIpAddress).HasMaxLength(20).IsRequired(false);
        builder.Property(item => item.UserAgent).HasMaxLength(500).IsRequired(false);
        builder.Property(item => item.Device).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.DeviceOs).HasMaxLength(50).IsRequired(false);
        builder.Property(item => item.BrowserInfo).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.ServiceName).HasMaxLength(500).IsRequired(false);
        builder.Property(item => item.MethodName).HasMaxLength(500).IsRequired(false);
        builder.Property(item => item.HttpMethod).HasMaxLength(10).IsRequired(false);
        builder.Property(item => item.RequestUrl).IsRequired(false);
        builder.Property(item => item.ResponseStatus).HasMaxLength(10).IsRequired(false);
        builder.Property(item => item.ExecutionTime).IsRequired(false);
        builder.Property(item => item.ExecutionDuration).HasMaxLength(50).IsRequired(false);
        builder.Property(item => item.RequestHeaders).IsRequired(false);
        builder.Property(item => item.RequestQuery).IsRequired(false);
        builder.Property(item => item.RequestBody).IsRequired(false);
    }
}