using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.AuditLog.EntityConfigurations;

public class AppEntityPropertyChangeConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppEntityPropertyChange>
{
    public void Configure(EntityTypeBuilder<AppEntityPropertyChange> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppEntityPropertyChanges");
        
        builder.Property(item => item.NewValue).IsRequired(false);
        builder.Property(item => item.OriginalValue).IsRequired(false);
        builder.Property(item => item.PropertyName).HasMaxLength(500).IsRequired();
        builder.Property(item => item.PropertyTypeFullName).HasMaxLength(1000).IsRequired();
        
        builder.HasOne<AppAuditLog>().WithMany().HasForeignKey(item => item.AuditLogId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}