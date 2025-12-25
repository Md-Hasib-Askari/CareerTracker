namespace CareerTracker.Application.Features.Jobs.Commands;

public record JobPostCreateCommand
{
    public Guid JobSourceId { get; init; }
    public string ExternalId { get; init; } = string.Empty;
    public string Title { get; init; } = default!;
    public string CompanyName { get; init; } = default!;
    public string Location { get; init; } = string.Empty;
    public RemoteType RemoteType { get; init; } = RemoteType.Unknown;
    public EmploymentType EmploymentType { get; init; } = EmploymentType.Unknown;
    public string Description { get; init; } = default!;
    public string Url { get; init; } = default!;
    public DateTime? PostedAt { get; init; }
    public DateTime CollectedAt { get; init; }
}