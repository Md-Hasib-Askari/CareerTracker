namespace CareerTracker.Application.Features.Jobs.DTOs;

public class JobPostDto
{
    public Guid Id { get; set; }
    public Guid JobSourceId { get; set; }
    public string ExternalId { get; set; } = string.Empty;
    public string Title { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
    public string Location { get; set; } = string.Empty;
    public string RemoteType { get; set; } = string.Empty;
    public string EmploymentType { get; set; } = string.Empty;
    public string Description { get; set; } = default!;
    public string Url { get; set; } = default!;
    public DateTime? PostedAt { get; set; }
    public DateTime CollectedAt { get; set; }
    public bool IsActive { get; set; }
}
