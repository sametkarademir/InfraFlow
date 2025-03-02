using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppAccessTokenConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppAccessToken>
{
    public void Configure(EntityTypeBuilder<AppAccessToken> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppAccessTokens");
        builder.HasIndex(item => item.Token);
        
        builder.Property(item => item.Token).HasMaxLength(1000).IsRequired();
        builder.Property(item => item.ExpiresAt).IsRequired();
        
        builder.Property(item => item.IsRevoked).IsRequired();
        builder.Property(item => item.RevokedAt).IsRequired(false);
        
        builder.HasOne(item => item.AppUser).WithMany().HasForeignKey(item => item.AppUserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}