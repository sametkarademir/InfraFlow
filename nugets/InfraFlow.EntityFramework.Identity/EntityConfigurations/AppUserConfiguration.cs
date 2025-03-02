using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppUserConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppUsers");

        builder.HasIndex(item => item.NormalizedUserName).IsUnique();
        builder.HasIndex(item => item.NormalizedEmail).IsUnique();
        builder.HasIndex(item => item.EmailVerified);
        builder.HasIndex(item => item.PhoneVerified);
        builder.HasIndex(item => item.IsActive);
        builder.HasIndex(item => item.LockoutEnabled);
        builder.HasIndex(item => item.LockoutEnd);

        builder.HasIndex(item => new { item.LockoutEnabled, item.LockoutEnd });
        builder.HasIndex(item => new { item.EmailVerified, item.IsActive });
        
        builder.Property(item => item.UserName).HasMaxLength(256).IsRequired();
        builder.Property(item => item.NormalizedUserName).HasMaxLength(256).IsRequired();
        
        builder.Property(item => item.Email).HasMaxLength(256).IsRequired();
        builder.Property(item => item.NormalizedEmail).HasMaxLength(256).IsRequired();
        builder.Property(item => item.EmailVerified).IsRequired();
        
        builder.Property(item => item.PasswordHash).HasMaxLength(1000).IsRequired();
        builder.Property(item => item.Salt).HasMaxLength(100).IsRequired();
        builder.Property(item => item.SecurityStamp).HasMaxLength(100).IsRequired();
        builder.Property(item => item.PasswordChangedTime).IsRequired(false);

        builder.Property(item => item.PhoneNumber).HasMaxLength(1000).IsRequired(false);
        builder.Property(item => item.PhoneVerified).IsRequired();
        
        builder.Property(item => item.IsActive).IsRequired();
        
        builder.Property(item => item.TwoFactorEnabled).IsRequired();
        builder.Property(item => item.TwoFactorSecret).HasMaxLength(1000).IsRequired(false);
        
        builder.Property(item => item.LockoutEnd).IsRequired(false);
        builder.Property(item => item.LockoutEnabled).IsRequired();
        builder.Property(item => item.AccessFailedCount).IsRequired();
    }
}