using InfraFlow.EntityFramework.Identity.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.EntityFramework.Identity.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkIdentityServices<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddScoped<IAppAccessTokenRepository, AppAccessTokenRepository<TContext>>();
        services.AddScoped<IAppPermissionRepository, AppPermissionRepository<TContext>>();
        services.AddScoped<IAppRefreshTokenRepository, AppRefreshTokenRepository<TContext>>();
        services.AddScoped<IAppRolePermissionRepository, AppRolePermissionRepository<TContext>>();
        services.AddScoped<IAppRoleRepository, AppRoleRepository<TContext>>();
        services.AddScoped<IAppUserFailedLoginAttemptRepository, AppUserFailedLoginAttemptRepository<TContext>>();
        services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository<TContext>>();
        services.AddScoped<IAppUserRepository, AppUserRepository<TContext>>();
        services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository<TContext>>();
        services.AddScoped<IAppUserSessionRepository, AppUserSessionRepository<TContext>>();
        services.AddScoped<IAppVerificationCodeRepository, AppVerificationCodeRepository<TContext>>();
        
        return services;
    }
}