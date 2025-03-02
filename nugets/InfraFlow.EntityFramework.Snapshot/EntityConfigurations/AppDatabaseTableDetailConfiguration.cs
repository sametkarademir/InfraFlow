using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Snapshot.EntityConfigurations;

public class AppDatabaseTableDetailConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppDatabaseTableDetail>
{
    public void Configure(EntityTypeBuilder<AppDatabaseTableDetail> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppDatabaseTableDetails");

        builder.Property(item => item.TableName).HasMaxLength(500).IsRequired(false);
        builder.Property(item => item.RecordCount).IsRequired();
        
        builder.HasOne<AppDatabaseDetail>().WithMany(item => item.AppDatabaseTableDetails).HasForeignKey(item => item.AppDatabaseDetailId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}