using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppRefreshTokenConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppRefreshToken>
{
    public void Configure(EntityTypeBuilder<AppRefreshToken> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppRefreshTokens");
        builder.HasIndex(item => item.Token);
        
        builder.Property(item => item.Token).HasMaxLength(500).IsRequired();
        builder.Property(item => item.ExpiresAt).IsRequired();
        
        builder.Property(item => item.IsUsed).IsRequired();
        builder.Property(item => item.IsRevoked).IsRequired();
        builder.Property(item => item.RevokedAt).IsRequired(false);
        builder.Property(item => item.ReplacedByToken).HasMaxLength(500).IsRequired(false);
        
        builder.HasOne(item => item.AppUser).WithMany().HasForeignKey(item => item.AppUserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}