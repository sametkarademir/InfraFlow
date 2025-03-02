using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Snapshot.EntityConfigurations;

public class AppDatabaseDetailConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppDatabaseDetail>
{
    public void Configure(EntityTypeBuilder<AppDatabaseDetail> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppDatabaseDetails");

        builder.Property(item => item.Host).HasMaxLength(500).IsRequired(false);
        builder.Property(item => item.DatabaseName).HasMaxLength(500).IsRequired(false);
        builder.Property(item => item.DatabaseVersion).HasMaxLength(50).IsRequired(false);
        builder.Property(item => item.TableCount).IsRequired();
    }
}