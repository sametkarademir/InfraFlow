using System.Reflection;
using InfraFlow.Domain.Entities;
using InfraFlow.EntityFramework.Contexts;
using InfraFlow.EntityFramework.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.Infrastructure.Contexts;

public class ApplicationDbContext : BaseDbContext
{
    public DbSet<Todo> Todos { get; set; }
    
    public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor, DatabaseProviderTypes.PostgreSql)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}