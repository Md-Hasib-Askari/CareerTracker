public class Application
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid JobPostId { get; set; }

    public ApplicationStatus Status { get; set; }
    public DateTime? AppliedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public string? Notes { get; set; }

    public User User { get; set; } = default!;
    public JobPost JobPost { get; set; } = default!;
}
