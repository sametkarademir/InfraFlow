using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Identity.EntityConfigurations;

public class AppVerificationCodeConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppVerificationCode>
{
    public void Configure(EntityTypeBuilder<AppVerificationCode> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppVerificationCodes");
        builder.HasIndex(item => item.Code);
        
        builder.Property(item => item.Code).HasMaxLength(6).IsRequired();
        builder.Property(item => item.VerificationType).IsRequired();
        builder.Property(item => item.ExpiresAt).IsRequired();
        
        builder.Property(item => item.IsUsed).IsRequired();
        builder.Property(item => item.UsedAt).IsRequired(false);
        
        builder.HasOne(item => item.AppUser).WithMany().HasForeignKey(item => item.AppUserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}