namespace InfraFlow.Infrastructure.Snapshot.Services.AppSnapshots;

public interface IAppSnapshotInitializerService
{
    Task TakeAppSnapshotAsync();
}