using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAssemblies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Culture = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PublicKeyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAssemblies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppAuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EntityName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EntityState = table.Column<int>(type: "integer", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppConfigurationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigurationDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppDatabaseDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Host = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DatabaseName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DatabaseVersion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TableCount = table.Column<int>(type: "integer", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDatabaseDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    StackTrace = table.Column<string>(type: "text", nullable: true),
                    InnerException = table.Column<string>(type: "text", nullable: true),
                    ResponseBody = table.Column<string>(type: "text", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppExceptionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppHttpRequestLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    User = table.Column<string>(type: "text", nullable: true),
                    ClientIpAddress = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UserAgent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Device = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeviceOs = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BrowserInfo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ServiceName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MethodName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HttpMethod = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    RequestUrl = table.Column<string>(type: "text", nullable: true),
                    ResponseStatus = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ExecutionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExecutionDuration = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RequestHeaders = table.Column<string>(type: "text", nullable: true),
                    RequestQuery = table.Column<string>(type: "text", nullable: true),
                    RequestBody = table.Column<string>(type: "text", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppHttpRequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Resource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NormalizedName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSnapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ApplicationVersion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Environment = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MachineName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    MachineOsVersion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Platform = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CultureInfo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CpuCoreCount = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CpuArchitecture = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TotalRam = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    TotalDiskSpace = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    InterfaceName = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    IpAddress = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Hostname = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSnapshots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTodos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    EmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Salt = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SecurityStamp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordChangedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PhoneVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorSecret = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewValue = table.Column<string>(type: "text", nullable: true),
                    OriginalValue = table.Column<string>(type: "text", nullable: true),
                    PropertyName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PropertyTypeFullName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AuditLogId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppAuditLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppEntityPropertyChanges_AppAuditLogs_AppAuditLogId",
                        column: x => x.AppAuditLogId,
                        principalTable: "AppAuditLogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppEntityPropertyChanges_AppAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AppAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppDatabaseTableDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TableName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RecordCount = table.Column<long>(type: "bigint", nullable: false),
                    AppDatabaseDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDatabaseTableDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDatabaseTableDetails_AppDatabaseDetails_AppDatabaseDetai~",
                        column: x => x.AppDatabaseDetailId,
                        principalTable: "AppDatabaseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppPermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRolePermissions_AppPermissions_AppPermissionId",
                        column: x => x.AppPermissionId,
                        principalTable: "AppPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRolePermissions_AppRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppAccessTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAccessTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAccessTokens_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRefreshTokens_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserFailedLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    FailureReason = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserFailedLoginAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserFailedLoginAttempts_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserProfiles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessToken = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    RefreshToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AccessTokenExpiredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RefreshTokenExpiredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserSessions_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppVerificationCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    VerificationType = table.Column<int>(type: "integer", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    AppSnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "jsonb", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVerificationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppVerificationCodes_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAccessTokens_AppSnapshotId",
                table: "AppAccessTokens",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAccessTokens_AppUserId",
                table: "AppAccessTokens",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAccessTokens_CorrelationId",
                table: "AppAccessTokens",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAccessTokens_CreatorId",
                table: "AppAccessTokens",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAccessTokens_SessionId",
                table: "AppAccessTokens",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAccessTokens_Token",
                table: "AppAccessTokens",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssemblies_AppSnapshotId",
                table: "AppAssemblies",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssemblies_CorrelationId",
                table: "AppAssemblies",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssemblies_CreatorId",
                table: "AppAssemblies",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssemblies_SessionId",
                table: "AppAssemblies",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAuditLogs_AppSnapshotId",
                table: "AppAuditLogs",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAuditLogs_CorrelationId",
                table: "AppAuditLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAuditLogs_CreatorId",
                table: "AppAuditLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAuditLogs_SessionId",
                table: "AppAuditLogs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurationDetails_AppSnapshotId",
                table: "AppConfigurationDetails",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurationDetails_CorrelationId",
                table: "AppConfigurationDetails",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurationDetails_CreatorId",
                table: "AppConfigurationDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurationDetails_SessionId",
                table: "AppConfigurationDetails",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseDetails_AppSnapshotId",
                table: "AppDatabaseDetails",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseDetails_CorrelationId",
                table: "AppDatabaseDetails",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseDetails_CreatorId",
                table: "AppDatabaseDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseDetails_SessionId",
                table: "AppDatabaseDetails",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseTableDetails_AppDatabaseDetailId",
                table: "AppDatabaseTableDetails",
                column: "AppDatabaseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseTableDetails_AppSnapshotId",
                table: "AppDatabaseTableDetails",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseTableDetails_CorrelationId",
                table: "AppDatabaseTableDetails",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseTableDetails_CreatorId",
                table: "AppDatabaseTableDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDatabaseTableDetails_SessionId",
                table: "AppDatabaseTableDetails",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEntityPropertyChanges_AppAuditLogId",
                table: "AppEntityPropertyChanges",
                column: "AppAuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEntityPropertyChanges_AppSnapshotId",
                table: "AppEntityPropertyChanges",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEntityPropertyChanges_AuditLogId",
                table: "AppEntityPropertyChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEntityPropertyChanges_CorrelationId",
                table: "AppEntityPropertyChanges",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEntityPropertyChanges_CreatorId",
                table: "AppEntityPropertyChanges",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEntityPropertyChanges_SessionId",
                table: "AppEntityPropertyChanges",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExceptionLogs_AppSnapshotId",
                table: "AppExceptionLogs",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExceptionLogs_CorrelationId",
                table: "AppExceptionLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExceptionLogs_CreatorId",
                table: "AppExceptionLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExceptionLogs_SessionId",
                table: "AppExceptionLogs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppHttpRequestLogs_AppSnapshotId",
                table: "AppHttpRequestLogs",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppHttpRequestLogs_CorrelationId",
                table: "AppHttpRequestLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppHttpRequestLogs_CreatorId",
                table: "AppHttpRequestLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppHttpRequestLogs_SessionId",
                table: "AppHttpRequestLogs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermissions_AppSnapshotId",
                table: "AppPermissions",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermissions_CorrelationId",
                table: "AppPermissions",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermissions_CreatorId",
                table: "AppPermissions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermissions_DeleterId",
                table: "AppPermissions",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermissions_LastModifierId",
                table: "AppPermissions",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPermissions_Name",
                table: "AppPermissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPermissions_SessionId",
                table: "AppPermissions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRefreshTokens_AppSnapshotId",
                table: "AppRefreshTokens",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRefreshTokens_AppUserId",
                table: "AppRefreshTokens",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRefreshTokens_CorrelationId",
                table: "AppRefreshTokens",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRefreshTokens_CreatorId",
                table: "AppRefreshTokens",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRefreshTokens_SessionId",
                table: "AppRefreshTokens",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRefreshTokens_Token",
                table: "AppRefreshTokens",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_AppPermissionId",
                table: "AppRolePermissions",
                column: "AppPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_AppRoleId",
                table: "AppRolePermissions",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_AppSnapshotId",
                table: "AppRolePermissions",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_CorrelationId",
                table: "AppRolePermissions",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_CreatorId",
                table: "AppRolePermissions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_SessionId",
                table: "AppRolePermissions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_AppSnapshotId",
                table: "AppRoles",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_CorrelationId",
                table: "AppRoles",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_CreatorId",
                table: "AppRoles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_DeleterId",
                table: "AppRoles",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_LastModifierId",
                table: "AppRoles",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_SessionId",
                table: "AppRoles",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSnapshots_AppSnapshotId",
                table: "AppSnapshots",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSnapshots_CorrelationId",
                table: "AppSnapshots",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSnapshots_CreatorId",
                table: "AppSnapshots",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSnapshots_SessionId",
                table: "AppSnapshots",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTodos_AppSnapshotId",
                table: "AppTodos",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTodos_CorrelationId",
                table: "AppTodos",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTodos_CreatorId",
                table: "AppTodos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTodos_DeleterId",
                table: "AppTodos",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTodos_LastModifierId",
                table: "AppTodos",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTodos_SessionId",
                table: "AppTodos",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserFailedLoginAttempts_AppSnapshotId",
                table: "AppUserFailedLoginAttempts",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserFailedLoginAttempts_AppUserId",
                table: "AppUserFailedLoginAttempts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserFailedLoginAttempts_CorrelationId",
                table: "AppUserFailedLoginAttempts",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserFailedLoginAttempts_CreatorId",
                table: "AppUserFailedLoginAttempts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserFailedLoginAttempts_SessionId",
                table: "AppUserFailedLoginAttempts",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_AppSnapshotId",
                table: "AppUserProfiles",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_AppUserId",
                table: "AppUserProfiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_CorrelationId",
                table: "AppUserProfiles",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_CreatorId",
                table: "AppUserProfiles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_DeleterId",
                table: "AppUserProfiles",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_LastModifierId",
                table: "AppUserProfiles",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_SessionId",
                table: "AppUserProfiles",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppRoleId",
                table: "AppUserRoles",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppSnapshotId",
                table: "AppUserRoles",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_CorrelationId",
                table: "AppUserRoles",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_CreatorId",
                table: "AppUserRoles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_SessionId",
                table: "AppUserRoles",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppSnapshotId",
                table: "AppUsers",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CorrelationId",
                table: "AppUsers",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CreatorId",
                table: "AppUsers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DeleterId",
                table: "AppUsers",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_EmailVerified",
                table: "AppUsers",
                column: "EmailVerified");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_EmailVerified_IsActive",
                table: "AppUsers",
                columns: new[] { "EmailVerified", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_IsActive",
                table: "AppUsers",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_LastModifierId",
                table: "AppUsers",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_LockoutEnabled",
                table: "AppUsers",
                column: "LockoutEnabled");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_LockoutEnabled_LockoutEnd",
                table: "AppUsers",
                columns: new[] { "LockoutEnabled", "LockoutEnd" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_LockoutEnd",
                table: "AppUsers",
                column: "LockoutEnd");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_NormalizedEmail",
                table: "AppUsers",
                column: "NormalizedEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_NormalizedUserName",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_PhoneVerified",
                table: "AppUsers",
                column: "PhoneVerified");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_SessionId",
                table: "AppUsers",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSessions_AccessToken",
                table: "AppUserSessions",
                column: "AccessToken");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSessions_AppSnapshotId",
                table: "AppUserSessions",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSessions_AppUserId",
                table: "AppUserSessions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSessions_CorrelationId",
                table: "AppUserSessions",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSessions_CreatorId",
                table: "AppUserSessions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSessions_RefreshToken",
                table: "AppUserSessions",
                column: "RefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSessions_SessionId",
                table: "AppUserSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_AppSnapshotId",
                table: "AppVerificationCodes",
                column: "AppSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_AppUserId",
                table: "AppVerificationCodes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_Code",
                table: "AppVerificationCodes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_CorrelationId",
                table: "AppVerificationCodes",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_CreatorId",
                table: "AppVerificationCodes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_DeleterId",
                table: "AppVerificationCodes",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_LastModifierId",
                table: "AppVerificationCodes",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerificationCodes_SessionId",
                table: "AppVerificationCodes",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAccessTokens");

            migrationBuilder.DropTable(
                name: "AppAssemblies");

            migrationBuilder.DropTable(
                name: "AppConfigurationDetails");

            migrationBuilder.DropTable(
                name: "AppDatabaseTableDetails");

            migrationBuilder.DropTable(
                name: "AppEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AppExceptionLogs");

            migrationBuilder.DropTable(
                name: "AppHttpRequestLogs");

            migrationBuilder.DropTable(
                name: "AppRefreshTokens");

            migrationBuilder.DropTable(
                name: "AppRolePermissions");

            migrationBuilder.DropTable(
                name: "AppSnapshots");

            migrationBuilder.DropTable(
                name: "AppTodos");

            migrationBuilder.DropTable(
                name: "AppUserFailedLoginAttempts");

            migrationBuilder.DropTable(
                name: "AppUserProfiles");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserSessions");

            migrationBuilder.DropTable(
                name: "AppVerificationCodes");

            migrationBuilder.DropTable(
                name: "AppDatabaseDetails");

            migrationBuilder.DropTable(
                name: "AppAuditLogs");

            migrationBuilder.DropTable(
                name: "AppPermissions");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
