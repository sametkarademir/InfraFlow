using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.AuditLog.EntityConfigurations;

public class AppAuditLogConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppAuditLog>
{
    public void Configure(EntityTypeBuilder<AppAuditLog> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppAuditLogs");
        
        builder.Property(item => item.EntityId).HasMaxLength(50).IsRequired();
        builder.Property(item => item.EntityName).HasMaxLength(500).IsRequired();
        builder.Property(item => item.EntityState).IsRequired();
    }
}