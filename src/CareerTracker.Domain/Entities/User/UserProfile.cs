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

    public List<string> Skills { get; set; } = new List<string>();
    public int? YearsOfExperience { get; set; }
    public List<string> PreferredJobTitles { get; set; } = new List<string>();
    public List<string> PreferredLocations { get; set; } = new List<string>();
    public List<string> PreferredJobTypes { get; set; } = new List<string>();
    public decimal? MinSalaryExpectation { get; set; }
    public string? Currency { get; set; }
    public RemotePreference RemotePreference { get; set; } = RemotePreference.Any;

    public User User { get; set; } = default!;

    public void Update(
        string firstName,
        string lastName,
        string headline,
        string bio,
        string? address,
        string? phoneNumber,
        List<string> skills,
        int? yearsOfExperience,
        List<string> preferredJobTitles,
        List<string> preferredLocations,
        List<string> preferredJobTypes,
        decimal? minSalaryExpectation,
        string? currency,
        RemotePreference remotePreference)
    {
        FirstName = firstName;
        LastName = lastName;
        Headline = headline;
        Bio = bio;
        Address = address;
        PhoneNumber = phoneNumber;
        Skills = skills;
        YearsOfExperience = yearsOfExperience;
        PreferredJobTitles = preferredJobTitles;
        PreferredLocations = preferredLocations;
        PreferredJobTypes = preferredJobTypes;
        MinSalaryExpectation = minSalaryExpectation;
        Currency = currency;
        RemotePreference = remotePreference;
    }

}