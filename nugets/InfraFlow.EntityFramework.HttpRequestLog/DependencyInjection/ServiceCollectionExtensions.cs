using InfraFlow.EntityFramework.HttpRequestLog.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.EntityFramework.HttpRequestLog.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkHttpRequestLogServices<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddScoped<IAppHttpRequestLogRepository, AppHttpRequestLogRepository<TContext>>();
        
        return services;
    }
}