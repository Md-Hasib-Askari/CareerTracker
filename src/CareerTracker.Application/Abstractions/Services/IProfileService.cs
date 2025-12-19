using CareerTracker.Application.Profiles.Dtos;

public interface IProfileService
{
    Task<ProfileDto?> GetProfileAsync(Guid userId, CancellationToken cancellationToken = default);
    Task UpsertProfileAsync(Guid userId, ProfileDto profileDto, CancellationToken cancellationToken = default);
}