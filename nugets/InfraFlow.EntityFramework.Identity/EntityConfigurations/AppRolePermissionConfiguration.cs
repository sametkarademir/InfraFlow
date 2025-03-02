using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppRolePermissionConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppRolePermission>
{
    public void Configure(EntityTypeBuilder<AppRolePermission> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppRolePermissions");
        
        builder.HasOne(item => item.AppRole).WithMany(item => item.AppRolePermissions)
            .HasForeignKey(item => item.AppRoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(item => item.AppPermission).WithMany(item => item.AppRolePermissions)
            .HasForeignKey(item => item.AppPermissionId).IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}