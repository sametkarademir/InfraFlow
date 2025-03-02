using InfraFlow.EntityFramework.AuditLog.DependencyInjection;
using InfraFlow.EntityFramework.Contexts;
using InfraFlow.EntityFramework.ExceptionLog.DependencyInjection;
using InfraFlow.EntityFramework.HttpRequestLog.DependencyInjection;
using InfraFlow.EntityFramework.Identity.DependencyInjection;
using InfraFlow.EntityFramework.Snapshot.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.EntityFramework.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkServices<TContext>(this IServiceCollection services) where TContext : BaseDbContext
    {
        services.AddEntityFrameworkAuditLogServices<TContext>();
        services.AddEntityFrameworkExceptionLogServices<TContext>();
        services.AddEntityFrameworkHttpRequestLogServices<TContext>();
        services.AddEntityFrameworkIdentityServices<TContext>();
        services.AddEntityFrameworkSnapshotServices<TContext>();
        
        return services;
    }
}