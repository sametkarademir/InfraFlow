using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppUserFailedLoginAttemptConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppUserFailedLoginAttempt>
{
    public void Configure(EntityTypeBuilder<AppUserFailedLoginAttempt> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppUserFailedLoginAttempts");
        
        builder.Property(item => item.UserName).HasMaxLength(256).IsRequired();
        builder.Property(item => item.FailureReason).IsRequired();
        
        builder.HasOne(item => item.AppUser).WithMany().HasForeignKey(item => item.AppUserId)
            .IsRequired(false).OnDelete(DeleteBehavior.NoAction);
    }
}