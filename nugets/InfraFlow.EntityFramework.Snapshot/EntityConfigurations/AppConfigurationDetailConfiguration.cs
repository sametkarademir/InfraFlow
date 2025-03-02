using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Snapshot.EntityConfigurations;

public class AppConfigurationDetailConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppConfigurationDetail>
{
    public void Configure(EntityTypeBuilder<AppConfigurationDetail> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppConfigurationDetails");

        builder.Property(item => item.Key).IsRequired();
        builder.Property(item => item.Value).IsRequired();
    }
}