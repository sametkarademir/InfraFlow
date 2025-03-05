using InfraFlow.Infrastructure.Snapshot.Models;
using InfraFlow.Infrastructure.Snapshot.Services;
using InfraFlow.Infrastructure.Snapshot.Services.AppAssemblies;
using InfraFlow.Infrastructure.Snapshot.Services.AppConfigurationDetails;
using InfraFlow.Infrastructure.Snapshot.Services.AppDatabaseDetails;
using InfraFlow.Infrastructure.Snapshot.Services.AppSnapshots;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.Infrastructure.Snapshot.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureSnapshotServices(this IServiceCollection services, Action<SnapshotOptions> options)
    {
        var snapshotOptions = new SnapshotOptions();
        options(snapshotOptions);
        services.Configure(options);
        
        services.AddHostedService<AppInitializer>();
        services.AddMemoryCache();
        
        services.AddScoped<IAppSnapshotInitializerService, AppSnapshotInitializerService>();
        services.AddScoped<IAppSnapshotAppService, AppSnapshotAppService>();
        services.AddScoped<IAppDatabaseDetailAppService, AppDatabaseDetailAppService>();
        services.AddScoped<IAppConfigurationDetailAppService, AppConfigurationDetailAppService>();
        services.AddScoped<IAppAssemblyAppService, AppAssemblyAppService>();
        
        return services;
    }
}