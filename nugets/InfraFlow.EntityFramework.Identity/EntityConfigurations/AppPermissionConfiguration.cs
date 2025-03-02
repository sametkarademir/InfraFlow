using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppPermissionConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppPermission>
{
    public void Configure(EntityTypeBuilder<AppPermission> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppPermissions");
        builder.HasIndex(item => item.Name).IsUnique();

        builder.Property(item => item.Description).HasMaxLength(1000).IsRequired(false);
        builder.Property(item => item.Resource).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.Action).HasMaxLength(100).IsRequired(false);
    }
}