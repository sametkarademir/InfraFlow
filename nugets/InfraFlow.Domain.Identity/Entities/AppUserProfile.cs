using InfraFlow.Domain.Core.Aggregates.FullAuditedAggregateRoots;

namespace InfraFlow.Domain.Identity.Entities;

public class AppUserProfile : FullAuditedAggregateRoot<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}