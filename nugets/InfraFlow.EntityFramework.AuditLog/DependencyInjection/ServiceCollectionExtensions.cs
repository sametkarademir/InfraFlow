using InfraFlow.EntityFramework.AuditLog.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.EntityFramework.AuditLog.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkAuditLogServices<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddScoped<IAppAuditLogRepository, AppAuditLogRepository<TContext>>();
        services.AddScoped<IAppEntityPropertyChangeRepository, AppEntityPropertyChangeRepository<TContext>>();
        
        return services;
    }
}