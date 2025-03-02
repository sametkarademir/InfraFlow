namespace InfraFlow.Application.Services.Interfaces.Snapshots;

public interface IAppSnapshotInitializerService
{
    Task TakeAppSnapshotAsync();
}