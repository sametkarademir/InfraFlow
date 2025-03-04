using InfraFlow.EntityFramework.Core.Enums;

namespace InfraFlow.Infrastructure.Snapshot.Models;

public class SnapshotOptions
{
    public DatabaseProviderTypes DatabaseProviderType { get; set; }
    public string ConnectionString { get; set; } = null!;
    public bool IsAppSnapshotEnabled { get; set; }
    public bool IsAppDatabaseDetailEnabled { get; set; }
    public bool IsAppConfigurationDetailEnabled { get; set; }
    public bool IsAppAssemblyEnabled { get; set; }
}