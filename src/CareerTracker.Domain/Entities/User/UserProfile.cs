public class UserProfile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Headline { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public string SkillsJson { get; set; } = "[]"; // Stored as JSON array
    public int? YearsOfExperience { get; set; }
    public string PreferredJobTitlesJson { get; set; } = "[]"; // Stored as JSON array
    public string PreferredLocationsJson { get; set; } = "[]"; // Stored as JSON array
    public string PreferredJobTypesJson { get; set; } = "[]"; // Stored as JSON array

    public decimal? MinSalaryExpectation { get; set; }
    public string? Currency { get; set; }
    public RemotePreference RemotePreference { get; set; } = RemotePreference.Any;

    public User User { get; set; } = default!;

}