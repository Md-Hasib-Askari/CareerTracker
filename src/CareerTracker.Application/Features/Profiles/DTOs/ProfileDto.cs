namespace CareerTracker.Application.Profiles.Dtos;

public sealed record ProfileDto(
    string FirstName,
    string LastName,
    string? Headline,
    string? Bio,
    string? PhoneNumber,
    string? Address,
    List<string> Skills,
    int? YearsOfExperience,
    List<string> PreferredJobTitles,
    List<string> PreferredLocations,
    List<string> PreferredJobTypes,
    decimal? MinSalaryExpectation,
    string? Currency,
    RemotePreference RemotePreference
);
