using CareerTracker.Application.Profiles.Dtos;

public class ProfileService : IProfileService
{
    private readonly IUserProfileRepository _profileRepo;
    public ProfileService(IUserProfileRepository profileRepo)
    {
        _profileRepo = profileRepo;
    }

    public async Task<ProfileDto?> GetProfileAsync(Guid userId, CancellationToken cancellationToken)
    {
        var profile = await _profileRepo.GetByUserIdAsync(userId, cancellationToken);
        if (profile == null) return null;

        return new ProfileDto(
            profile.FirstName,
            profile.LastName,
            profile.Headline,
            profile.Bio,
            profile.Address,
            profile.PhoneNumber,
            profile.Skills,
            profile.YearsOfExperience,
            profile.PreferredJobTitles,
            profile.PreferredLocations,
            profile.PreferredJobTypes,
            profile.MinSalaryExpectation,
            profile.Currency,
            profile.RemotePreference
        );
    }

    public async Task UpsertProfileAsync(Guid userId, ProfileDto profileDto, CancellationToken cancellationToken)
    {
        var profile = await _profileRepo.GetByUserIdAsync(userId, cancellationToken) ?? new UserProfile { UserId = userId };
        profile.Update(
            profileDto.FirstName,
            profileDto.LastName,
            profileDto.Headline ?? string.Empty,
            profileDto.Bio ?? string.Empty,
            profileDto.Address,
            profileDto.PhoneNumber,
            profileDto.Skills,
            profileDto.YearsOfExperience,
            profileDto.PreferredJobTitles,
            profileDto.PreferredLocations,
            profileDto.PreferredJobTypes,
            profileDto.MinSalaryExpectation,
            profileDto.Currency,
            profileDto.RemotePreference
        );

        await _profileRepo.UpsertAsync(profile, cancellationToken);
    }
}