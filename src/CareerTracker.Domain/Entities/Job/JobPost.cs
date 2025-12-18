public class JobPost
{
    public Guid Id { get; set; }
    public Guid JobSourceId { get; set; }
    public string ExternalId { get; set; } = string.Empty;

    public string Title { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
    public string Location { get; set; } = string.Empty;
    public RemoteType RemoteType { get; set; } = RemoteType.Unknown;
    public EmploymentType EmploymentType { get; set; } = EmploymentType.Unknown;

    public string Description { get; set; } = default!;
    public string Url { get; set; } = default!;
    public DateTime? PostedAt { get; set; }
    public DateTime CollectedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public JobSource JobSource { get; set; } = default!;
    public ICollection<JobMatch> JobMatches { get; set; } = new List<JobMatch>();
    public ICollection<Application> Applications { get; set; } = new List<Application>();
}
