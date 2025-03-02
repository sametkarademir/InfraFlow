using InfraFlow.Domain.AuditLog.Entities;
using InfraFlow.Domain.Core.Extensions;
using InfraFlow.Domain.Core.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EntityState = InfraFlow.Domain.AuditLog.Enums.EntityState;

namespace InfraFlow.EntityFramework.AuditLog.Extensions;

public static class DbContextAuditLogExtensions
{
    public static async Task SetAuditLogAsync(this DbContext context, IHttpContextAccessor httpContextAccessor)
    {
        var auditEntries = context.ChangeTracker.Entries().ToList();

        foreach (var entry in auditEntries)
        {
            if (entry.Entity.GetType().GetCustomAttributes(typeof(ExcludeFromProcessingAttribute), true).Any())
            {
                continue;
            }

            var auditLog = new AppAuditLog
            {
                CorrelationId = httpContextAccessor.HttpContext.Request.GetCorrelationId(),
                AppSnapshotId = httpContextAccessor.HttpContext.Request.GetSnapshotId(),
                SessionId = httpContextAccessor.HttpContext.Request.GetSessionId(),
                EntityState = (EntityState)entry.State,
                EntityId = entry.OriginalValues[entry.Metadata.FindPrimaryKey()!.Properties.First().Name]!.ToString() ?? string.Empty,
                EntityName = entry.Metadata.GetTableName() ?? string.Empty,
                AppEntityPropertyChanges = new List<AppEntityPropertyChange>(),
                CreationTime = DateTime.UtcNow,
                CreatorId = httpContextAccessor.HttpContext.User.GetUserId(),
            };

            foreach (var property in entry.Properties)
            {
                var propertyInfo = entry.Entity.GetType().GetProperty(property.Metadata.Name);

                if (propertyInfo != null &&
                    propertyInfo.GetCustomAttributes(typeof(ExcludeFromProcessingAttribute), true).Any())
                {
                    continue;
                }

                bool ShouldLogChange(string? oldValue, string? newValue, EntityState eventType)
                {
                    if (property.GetType().GetCustomAttributes(typeof(ExcludeFromProcessingAttribute), true).Any())
                        return false;

                    return eventType == EntityState.Added || !Equals(oldValue, newValue);
                }

                var columnName = property.Metadata.Name;
                var oldValue = property.OriginalValue?.ToString();
                var newValue = property.CurrentValue?.ToString();

                if (ShouldLogChange(oldValue, newValue, auditLog.EntityState))
                {
                    var entityPropertyChange = new AppEntityPropertyChange
                    {
                        NewValue = newValue,
                        OriginalValue = EntityState.Added == auditLog.EntityState
                            ? null
                            : oldValue,
                        PropertyName = columnName,
                        PropertyTypeFullName = property.Metadata.ClrType.FullName ?? string.Empty,
                        AuditLogId = auditLog.Id,
                        CorrelationId = auditLog.CorrelationId,
                        AppSnapshotId = auditLog.AppSnapshotId,
                        SessionId = auditLog.SessionId,
                        CreationTime = auditLog.CreationTime,
                        CreatorId = auditLog.CreatorId,
                    };

                    auditLog.AppEntityPropertyChanges.Add(entityPropertyChange);
                }
            }

            await context.Set<AppAuditLog>().AddAsync(auditLog);
        }
    }
}