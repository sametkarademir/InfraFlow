using InfraFlow.Domain.Entities;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraFlow.Infrastructure.EntityConfigurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ApplyGlobalEntityConfigurations(DatabaseProviderTypes.PostgreSql);
        
        builder.ToTable("AppTodos");
        
        builder.Property(item => item.Name).HasMaxLength(100).IsRequired();
    }
}