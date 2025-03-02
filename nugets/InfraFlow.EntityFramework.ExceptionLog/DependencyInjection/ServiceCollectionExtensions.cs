using InfraFlow.EntityFramework.ExceptionLog.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.EntityFramework.ExceptionLog.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkExceptionLogServices<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddScoped<IAppExceptionLogRepository, AppExceptionLogRepository<TContext>>();
        
        return services;
    }
}