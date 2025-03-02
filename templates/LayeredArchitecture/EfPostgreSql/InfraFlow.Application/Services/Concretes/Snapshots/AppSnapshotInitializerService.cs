using System.Data.Common;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using InfraFlow.Application.Services.Interfaces.Snapshots;
using InfraFlow.Domain.Core.Aggregates.Entities;
using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Snapshot.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace InfraFlow.Application.Services.Concretes.Snapshots;

public class AppSnapshotInitializerService(
    ILogger<AppSnapshotService> logger,
    IConfiguration configuration,
    IAppSnapshotRepository appSnapshotRepository,
    IMemoryCache memoryCache)
    : IAppSnapshotInitializerService
{
    public async Task TakeAppSnapshotAsync()
    {
        try
        {
            var appSnapshot = GetAppSnapshot();
            await appSnapshotRepository.AddAsync(appSnapshot, true);

            memoryCache.Set(nameof(IAppSnapshotEntity), appSnapshot.Id);

            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                var appDatabaseDetail = await GetAppDatabaseDetail(appSnapshot.Id, connectionString);

                if (appDatabaseDetail != null)
                {
                    //await _appDatabaseDetailRepository.AddAsync(appDatabaseDetail, true);
                }
            }

            var appConfigurationDetails = GetAppConfigurationDetails(appSnapshot.Id);
            //await _appConfigurationDetailRepository.AddRangeAsync(appConfigurationDetails, true);

            var appAssemblies = GetAppAssemblies(appSnapshot.Id);
            //await _appAssemblyRepository.AddRangeAsync(appAssemblies, true);
        }
        catch (Exception e)
        {
            logger.LogError("Error taking app snapshot: {Error}", e.Message);
        }
    }

    #region AppSnapshot Methods

    private AppSnapshot GetAppSnapshot()
    {
        var applicationName = AppDomain.CurrentDomain.FriendlyName;
        var applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ??
                                 "Unknown";
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        var machineName = Environment.MachineName;
        var machineOsVersion = Environment.OSVersion.ToString();
        var platform = Environment.OSVersion.Platform.ToString();
        var cultureInfo = CultureInfo.CurrentCulture.Name;
        var cpuCoreCount = Environment.ProcessorCount.ToString();
        var cpuArchitecture = RuntimeInformation.OSArchitecture.ToString();
        var hostname = Dns.GetHostName();
        var totalDiskSpace = GetTotalDiskSpace();
        var ipAddress = GetIpAddress();
        var interfaceName = GetNetworkInterfaces();
        var totalRam = GetTotalRam();

        var appSnapshot = new AppSnapshot
        {
            ApplicationName = applicationName,
            ApplicationVersion = applicationVersion,
            Environment = environment,
            MachineName = machineName,
            MachineOsVersion = machineOsVersion,
            Platform = platform,
            CultureInfo = cultureInfo,
            CpuCoreCount = cpuCoreCount,
            CpuArchitecture = cpuArchitecture,
            TotalRam = totalRam,
            TotalDiskSpace = totalDiskSpace,
            InterfaceName = interfaceName,
            IpAddress = ipAddress,
            Hostname = hostname,
        };

        return appSnapshot;
    }

    private string GetTotalDiskSpace()
    {
        try
        {
            var drives = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Fixed).ToList();
            var result = drives
                .GroupBy(item => item.TotalSize)
                .Select(item => item.FirstOrDefault())
                .ToList();

            var totalSpace = result.Sum(item => item?.TotalSize);

            return (totalSpace / (1024 * 1024 * 1024)) + " GB";
        }
        catch (Exception e)
        {
            logger.LogError("Error getting total disk space: {Error}", e.Message);
            return "Unknown";
        }
    }

    private string GetIpAddress()
    {
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipList = host.AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                .Select(ip => ip.ToString())
                .ToList();

            return string.Join(", ", ipList);
        }
        catch (Exception e)
        {
            logger.LogError("Error getting IP address: {Error}", e.Message);
            return "Unknown";
        }
    }

    private string GetNetworkInterfaces()
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return GetNetworkInterfacesForWindows();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                     RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
#pragma warning disable CA1416
                return GetNetworkInterfacesForUnix();
#pragma warning restore CA1416
            }

            return "Unsupported OS";
        }
        catch (Exception e)
        {
            logger.LogError("Error getting network interfaces: {Error}", e.Message);
            return "Unknown";
        }
    }

    private string GetTotalRam()
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return GetTotalRamForWindows();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return GetTotalRamForUnix();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return GetTotalRamFromProcMemInfo();
            }

            return "Unsupported OS";
        }
        catch (Exception e)
        {
            logger.LogError("Error getting total RAM: {Error}", e.Message);
            return "Unknown";
        }
    }

    [SupportedOSPlatform("windows")]
    private string GetNetworkInterfacesForWindows()
    {
        try
        {
            using var searcher =
                new System.Management.ManagementObjectSearcher(
                    "SELECT Name FROM Win32_NetworkAdapter WHERE NetEnabled = true");
            var interfaces = searcher.Get()
                .Cast<System.Management.ManagementObject>()
                .Select(mo => mo["Name"]?.ToString())
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .ToList();

            return string.Join(", ", interfaces);
        }
        catch (Exception ex)
        {
            logger.LogError("Error retrieving network interfaces on Windows: {Error}", ex.Message);
            return "Unknown";
        }
    }

    [SupportedOSPlatform("osx")]
    private string GetNetworkInterfacesForUnix()
    {
        try
        {
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "sh",
                    Arguments = "-c \"ifconfig | grep -E '^[a-zA-Z]' | awk '{print $1}'\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            var result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var interfaces = result.Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToList();

            return string.Join(", ", interfaces);
        }
        catch (Exception ex)
        {
            logger.LogError("Error retrieving network interfaces on Unix: {Error}", ex.Message);
            return "Unknown";
        }
    }

    [SupportedOSPlatform("windows")]
    private string GetTotalRamForWindows()
    {
        try
        {
            using var searcher =
                new System.Management.ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory");
            var totalBytes = searcher.Get()
                .Cast<System.Management.ManagementObject>()
                .Sum(mo => Convert.ToInt64(mo["Capacity"]));

            return (totalBytes / (1024 * 1024 * 1024)) + " GB";
        }
        catch (Exception ex)
        {
            logger.LogError("Error retrieving total RAM on Windows: {Error}", ex.Message);
            return "Unknown";
        }
    }

    [SupportedOSPlatform("osx")]
    private string GetTotalRamForUnix()
    {
        try
        {
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "sh",
                    Arguments = "-c \"sysctl -n hw.memsize\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            var result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrWhiteSpace(result) && long.TryParse(result.Trim(), out long memBytes))
            {
                return (memBytes / (1024 * 1024 * 1024)) + " GB";
            }

            return "Unknown";
        }
        catch (Exception ex)
        {
            logger.LogError("Error retrieving total RAM on Unix: {Error}", ex.Message);
            return "Unknown";
        }
    }

    private string GetTotalRamFromProcMemInfo()
    {
        try
        {
            var lines = System.IO.File.ReadAllLines("/proc/meminfo");
            var memTotalLine = lines.FirstOrDefault(line => line.StartsWith("MemTotal:"));

            if (memTotalLine != null)
            {
                var parts = memTotalLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2 && long.TryParse(parts[1], out long memTotalKb))
                {
                    return (memTotalKb / (1024 * 1024)) + " GB";
                }
            }

            return "Unknown";
        }
        catch (Exception ex)
        {
            logger.LogError("Error retrieving total RAM from /proc/meminfo: {Error}", ex.Message);
            return "Unknown";
        }
    }

    #endregion

    #region AppDatabase Methods

    private async Task<AppDatabaseDetail?> GetAppDatabaseDetail(Guid snapshotId, string connectionString)
    {
        try
        {
            await using var connection = this.GetDbConnection(connectionString);
            await connection.OpenAsync();

            string databaseName = connection.Database;
            string databaseVersion = await GetDatabaseVersionAsync(connection);

            int tableCount = await GetTableCountAsync(connection);

            var databaseDetail = new AppDatabaseDetail
            {
                Host = connectionString,
                DatabaseName = databaseName,
                DatabaseVersion = databaseVersion,
                TableCount = tableCount,
                AppSnapshotId = snapshotId
            };

            var databaseTableDetails =
                await GetTotalRecordCountAsync(connection, connectionString, snapshotId, databaseDetail.Id);
            databaseDetail.AppDatabaseTableDetails = databaseTableDetails;

            return databaseDetail;
        }
        catch (Exception e)
        {
            logger.LogError("Error getting database detail: {Error}", e.Message);
            return null;
        }
    }

    private DbConnection GetDbConnection(string connectionString)
    {
        return new NpgsqlConnection(connectionString);
    }

    private async Task<string> GetDatabaseVersionAsync(DbConnection connection)
    {
        try
        {
            string query = "SHOW server_version";

            await using var command = connection.CreateCommand();
            command.CommandText = query;
            var result = await command.ExecuteScalarAsync();

            return result?.ToString() ?? "Unknown";
        }
        catch (Exception e)
        {
            logger.LogError("Error getting database version: {Error}", e.Message);
            return "Unknown";
        }
    }

    private async Task<int> GetTableCountAsync(DbConnection connection)
    {
        try
        {
            string query = "SELECT COUNT(*) FROM pg_tables WHERE schemaname = 'public'";

            await using var command = connection.CreateCommand();
            command.CommandText = query;

            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }
        catch (Exception e)
        {
            logger.LogError("Error getting table count: {Error}", e.Message);
            return 0;
        }
    }

    private async Task<List<AppDatabaseTableDetail>> GetTotalRecordCountAsync(DbConnection connection,
        string connectionString, Guid snapshotId, Guid databaseDetailId)
    {
        try
        {
            string tableQuery = "SELECT tablename FROM pg_tables WHERE schemaname = 'public'";

            await using var tableCommand = connection.CreateCommand();
            tableCommand.CommandText = tableQuery;

            await using var reader = await tableCommand.ExecuteReaderAsync();

            var databaseTables = new List<AppDatabaseTableDetail>();

            while (await reader.ReadAsync())
            {
                string tableName = reader.GetString(0);

                string countQuery = $"SELECT COUNT(*) FROM \"{tableName}\"";

                await using var newConnection = this.GetDbConnection(connectionString);
                await newConnection.OpenAsync();

                await using var countCommand = newConnection.CreateCommand();
                countCommand.CommandText = countQuery;
                long totalRecords = Convert.ToInt64(await countCommand.ExecuteScalarAsync());

                databaseTables.Add(new AppDatabaseTableDetail
                {
                    TableName = tableName,
                    RecordCount = totalRecords,
                    AppSnapshotId = snapshotId,
                    AppDatabaseDetailId = databaseDetailId
                });

                await newConnection.CloseAsync();
            }

            return databaseTables;
        }
        catch (Exception e)
        {
            logger.LogError("Error getting total record count: {Error}", e.Message);
            return new List<AppDatabaseTableDetail>();
        }
    }

    #endregion

    #region AppAssembly Methods

    private List<AppAssembly> GetAppAssemblies(Guid snapshotId)
    {
        try
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var appAssemblies = assemblies
                .Select(assembly => new AppAssembly
                {
                    Name = assembly.GetName().Name,
                    Version = assembly.GetName().Version?.ToString(),
                    Culture = assembly.GetName().CultureName ?? "neutral",
                    PublicKeyToken = BitConverter.ToString(assembly.GetName().GetPublicKeyToken() ?? new byte[0]),
                    Location = assembly.Location,
                    AppSnapshotId = snapshotId
                })
                .ToList();

            return appAssemblies;
        }
        catch (Exception e)
        {
            logger.LogError("Error getting app assemblies: {Error}", e.Message);
            return new List<AppAssembly>();
        }
    }

    #endregion

    #region AppConfigurationDetail Methods

    private List<AppConfigurationDetail> GetAppConfigurationDetails(Guid snapshotId)
    {
        try
        {
            var settings = new Dictionary<string, string>();
            FlattenConfiguration(configuration.AsEnumerable().ToDictionary(k => k.Key, v => v.Value), settings);

            var appSettingsEntities = settings.Select(kvp => new AppConfigurationDetail()
            {
                Key = kvp.Key,
                Value = kvp.Value,
                AppSnapshotId = snapshotId
            }).ToList();

            return appSettingsEntities;
        }
        catch (Exception e)
        {
            logger.LogError("Error getting app configuration details: {Error}", e.Message);
            return new List<AppConfigurationDetail>();
        }
    }

    private void FlattenConfiguration(Dictionary<string, string?> source, Dictionary<string, string> target,
        string parentKey = "")
    {
        foreach (var kvp in source)
        {
            var fullKey = string.IsNullOrEmpty(parentKey) ? kvp.Key : $"{parentKey}:{kvp.Key}";
            if (!string.IsNullOrEmpty(fullKey))
            {
                target[fullKey] = kvp.Value ?? "null";
            }
        }
    }

    #endregion
}