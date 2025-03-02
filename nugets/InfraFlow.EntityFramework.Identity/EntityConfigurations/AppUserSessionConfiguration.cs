using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppUserSessionConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppUserSession>
{
    public void Configure(EntityTypeBuilder<AppUserSession> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppUserSessions");
        builder.HasIndex(item => item.AccessToken);
        builder.HasIndex(item => item.RefreshToken);
        builder.Ignore(item => item.AccessTokenIsExpired);
        builder.Ignore(item => item.RefreshTokenIsExpired);
        
        builder.Property(item => item.AccessToken).HasMaxLength(1000).IsRequired();
        builder.Property(item => item.RefreshToken).HasMaxLength(500).IsRequired();
        builder.Property(item => item.AccessTokenExpiredTime).IsRequired();
        builder.Property(item => item.RefreshTokenExpiredTime).IsRequired();
        
        builder.HasOne(item => item.AppUser).WithMany().HasForeignKey(item => item.AppUserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}