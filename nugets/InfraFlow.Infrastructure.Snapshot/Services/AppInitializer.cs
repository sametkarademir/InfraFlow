using InfraFlow.Infrastructure.Snapshot.Services.AppSnapshots;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfraFlow.Infrastructure.Snapshot.Services;

public class AppInitializer(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Application is starting...");
        
        using var scope = serviceProvider.CreateScope();
        var appSnapshotInitializerService = scope.ServiceProvider.GetRequiredService<IAppSnapshotInitializerService>();
        await appSnapshotInitializerService.TakeAppSnapshotAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Application is stopping...");

        await Task.CompletedTask;
    }
}