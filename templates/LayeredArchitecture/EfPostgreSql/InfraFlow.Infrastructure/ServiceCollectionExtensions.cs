using InfraFlow.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfraFlow.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration["ConnectionStrings:DefaultConnection"] ?? "Host=localhost;Port=5432;Database=CleanArchTemplate;Username=postgres;Password=postgres";
        services.AddDbContextFactory<ApplicationDbContext>(
            opt => opt.UseNpgsql(connectionString),
            ServiceLifetime.Scoped
            );
        
        return services;
    }
}
