using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Snapshot.EntityConfigurations;

public class AppSnapshotConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppSnapshot>
{
    public void Configure(EntityTypeBuilder<AppSnapshot> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppSnapshots");
        
        builder.Property(item => item.ApplicationName).HasMaxLength(250).IsRequired(false);
        builder.Property(item => item.ApplicationVersion).HasMaxLength(20).IsRequired(false);
        builder.Property(item => item.Environment).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.MachineName).HasMaxLength(250).IsRequired(false);
        builder.Property(item => item.MachineOsVersion).HasMaxLength(20).IsRequired(false);
        builder.Property(item => item.Platform).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.CultureInfo).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.CpuCoreCount).HasMaxLength(5).IsRequired(false);
        builder.Property(item => item.CpuArchitecture).HasMaxLength(100).IsRequired(false);
        builder.Property(item => item.TotalRam).HasMaxLength(5).IsRequired(false);
        builder.Property(item => item.TotalDiskSpace).HasMaxLength(30).IsRequired(false);
        builder.Property(item => item.InterfaceName).HasMaxLength(2000).IsRequired(false);
        builder.Property(item => item.IpAddress).HasMaxLength(2000).IsRequired(false);
        builder.Property(item => item.Hostname).HasMaxLength(250).IsRequired(false);
    }
}