public class JobMatch
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid JobPostId { get; set; }

    public int MatchScore { get; set; }
    public bool IsNotified { get; set; }
    public DateTime? NotifiedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = default!;
    public JobPost JobPost { get; set; } = default!;
}
