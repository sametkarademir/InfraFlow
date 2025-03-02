using System.Security.Claims;

namespace InfraFlow.Domain.Core.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.NameIdentifier)?.Value != null ? Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value!) : null;
    public static string? GetUserName(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.Name)?.Value;
    public static string? GetUserEmail(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.Email)?.Value;
    public static string? GetUserCustomProperty(this ClaimsPrincipal user, string key) => user.FindFirst(key)?.Value;
    public static List<string>? GetUserRoles(this ClaimsPrincipal user) => user.FindAll(ClaimTypes.Role).Select(item => item.Value).ToList();
    public static List<string>? GetUserPermissions(this ClaimsPrincipal user) => user.FindAll("Permission").Select(item => item.Value).ToList();
}