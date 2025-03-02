using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppUserRoleConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppUserRoles");
        
        builder.HasOne(item => item.AppUser).WithMany(item => item.AppUserRoles).HasForeignKey(item => item.AppUserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(item => item.AppRole).WithMany(item => item.AppUserRoles).HasForeignKey(item => item.AppRoleId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}