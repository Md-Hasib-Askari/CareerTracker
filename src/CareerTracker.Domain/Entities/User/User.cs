public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public UserProfile? Profile { get; set; }
    public ICollection<Application> Applications { get; set; } = new List<Application>();
    public ICollection<JobMatch> JobMatches { get; set; } = new List<JobMatch>();
    public NotificationSettings? NotificationSettings { get; set; }
}