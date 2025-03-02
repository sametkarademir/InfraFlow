using System.Reflection;
using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.Domain.ExceptionLog.Entities;
using InfraFlow.Domain.HttpRequestLog.Entities;
using InfraFlow.Domain.Identity.Entities;
using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.AuditLog.EntityConfigurations;
using InfraFlow.EntityFramework.AuditLog.Extensions;
using InfraFlow.EntityFramework.Core.Enums;
using InfraFlow.EntityFramework.Core.Extensions;
using InfraFlow.EntityFramework.ExceptionLog.EntityConfigurations;
using InfraFlow.EntityFramework.HttpRequestLog.EntityConfigurations;
using InfraFlow.EntityFramework.Identity.EntityConfigurations;
using InfraFlow.EntityFramework.Snapshot.EntityConfigurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Contexts;

public abstract class BaseDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DatabaseProviderTypes _databaseProviderType;

    public DbSet<AppAuditLog> AppAuditLogs { get; set; }
    public DbSet<AppEntityPropertyChange> AppEntityPropertyChanges { get; set; }
    public DbSet<AppHttpRequestLog> HttpRequestLogs { get; set; }
    public DbSet<AppExceptionLog> AppExceptionLogs { get; set; }
    
    public DbSet<AppSnapshot> AppSnapshots { get; set; }
    public DbSet<AppAssembly> AppAssemblies { get; set; }
    public DbSet<AppConfigurationDetail> AppConfigurationDetails { get; set; }
    public DbSet<AppDatabaseDetail> AppDatabaseDetails { get; set; }
    public DbSet<AppDatabaseTableDetail> AppDatabaseTableDetails { get; set; }
    
    public DbSet<AppAccessToken> AppAccessTokens { get; set; }
    public DbSet<AppPermission> AppPermissions { get; set; }
    public DbSet<AppRefreshToken> AppRefreshTokens { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<AppRolePermission> AppRolePermissions { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppUserFailedLoginAttempt> AppUserFailedLoginAttempts { get; set; }
    public DbSet<AppUserProfile> AppUserProfiles { get; set; }
    public DbSet<AppUserRole> AppUserRoles { get; set; }
    public DbSet<AppUserSession> AppUserSessions { get; set; }
    public DbSet<AppVerificationCode> AppVerificationCodes { get; set; }

    public BaseDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor, DatabaseProviderTypes databaseProviderType) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _databaseProviderType = databaseProviderType;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.ApplyConfiguration(new AppAuditLogConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppEntityPropertyChangeConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppExceptionLogConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppHttpRequestLogConfiguration(_databaseProviderType));
        
        builder.ApplyConfiguration(new AppAssemblyConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppConfigurationDetailConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppDatabaseDetailConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppDatabaseTableDetailConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppSnapshotConfiguration(_databaseProviderType));
        
        builder.ApplyConfiguration(new AppAccessTokenConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppPermissionConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppRefreshTokenConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppRoleConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppRolePermissionConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppUserConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppUserFailedLoginAttemptConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppUserProfileConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppUserRoleConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppUserSessionConfiguration(_databaseProviderType));
        builder.ApplyConfiguration(new AppVerificationCodeConfiguration(_databaseProviderType));
    }

    public override int SaveChanges()
    {
        this.SetCreationTimestamps(_httpContextAccessor);
        this.SetModificationTimestamps(_httpContextAccessor);
        this.SetSoftDelete(_httpContextAccessor);
        this.SetAuditLogAsync(_httpContextAccessor).GetAwaiter();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.SetCreationTimestamps(_httpContextAccessor);
        this.SetModificationTimestamps(_httpContextAccessor);
        this.SetSoftDelete(_httpContextAccessor);
        await this.SetAuditLogAsync(_httpContextAccessor);
        return await base.SaveChangesAsync(cancellationToken);
    }
}