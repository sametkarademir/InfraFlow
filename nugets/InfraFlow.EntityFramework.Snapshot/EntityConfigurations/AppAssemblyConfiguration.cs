using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.EntityFramework.Snapshot.EntityConfigurations;

public class AppAssemblyConfiguration(DatabaseProviderTypes databaseProviderType) : IEntityTypeConfiguration<AppAssembly>
{
    public void Configure(EntityTypeBuilder<AppAssembly> builder)
    {
        builder.ApplyGlobalEntityConfigurations(databaseProviderType);
        
        builder.ToTable("AppAssemblies");
        
        builder.Property(item => item.Name).HasMaxLength(256).IsRequired(false);
        builder.Property(item => item.Version).HasMaxLength(50).IsRequired(false);
        builder.Property(item => item.Culture).HasMaxLength(256).IsRequired(false);
        builder.Property(item => item.PublicKeyToken).HasMaxLength(50).IsRequired(false);
        builder.Property(item => item.Location).HasMaxLength(2000).IsRequired(false);
    }
}