using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppUserProfileConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppUserProfile>
{
    public void Configure(EntityTypeBuilder<AppUserProfile> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppUserProfiles");
        
        builder.Property(item => item.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(item => item.LastName).HasMaxLength(100).IsRequired();
        builder.Property(item => item.DateOfBirth).IsRequired(false);
        
        builder.Property(item => item.ProfilePictureUrl).HasMaxLength(1000).IsRequired(false);
        builder.Property(item => item.Address).HasMaxLength(1000).IsRequired(false);
        builder.Property(item => item.City).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.Country).HasMaxLength(100).IsRequired(false);
        
        builder.HasOne(item => item.AppUser).WithOne(item => item.AppUserProfile)
            .HasForeignKey<AppUserProfile>(item => item.AppUserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}