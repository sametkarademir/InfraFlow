using InfraFlow.EntityFramework.Snapshot.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.EntityFramework.Snapshot.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkSnapshotServices<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddScoped<IAppSnapshotRepository, AppSnapshotRepository<TContext>>();
        services.AddScoped<IAppAssemblyRepository, AppAssemblyRepository<TContext>>();
        services.AddScoped<IAppConfigurationDetailRepository, AppConfigurationDetailRepository<TContext>>();
        services.AddScoped<IAppDatabaseDetailRepository, AppDatabaseDetailRepository<TContext>>();
        services.AddScoped<IAppDatabaseTableDetailRepository, AppDatabaseTableDetailRepository<TContext>>();
        
        return services;
    }
}