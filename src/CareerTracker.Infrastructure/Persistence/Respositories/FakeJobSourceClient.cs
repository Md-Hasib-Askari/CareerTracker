class FakeJobSourceClient : IJobSourceClient
{
    public string SourceName => "FakeSource";

    public Task<IEnumerable<JobPost>> FetchNewJobsAsync(string? query, CancellationToken cancellationToken)
    {
        var jobs = new List<JobPost>
        {
            new JobPost
            {
                Title = "Software Engineer",
                CompanyName = "Tech Corp",
                Location = "Remote",
                RemoteType = RemoteType.Remote,
                PostedAt = DateTime.UtcNow.AddDays(-2),
            },
            new JobPost
            {
                Title = "Senior Developer",
                CompanyName = "Innovate LLC",
                Location = "New York, NY",
                RemoteType = RemoteType.Onsite,
                PostedAt = DateTime.UtcNow.AddDays(-1),
                Url = "https://innovate.com/careers/2"
            },
            new JobPost
            {
                Title = "Junior Programmer",
                CompanyName = "Startup Inc",
                Location = "San Francisco, CA",
                RemoteType = RemoteType.Hybrid,
                PostedAt = DateTime.UtcNow,
                Url = "https://startup.com/jobs/3"
            },
            new JobPost
            {
                Title = "Backend Developer",
                CompanyName = "Web Solutions",
                Location = "Austin, TX",
                RemoteType = RemoteType.Onsite,
                PostedAt = DateTime.UtcNow.AddDays(-3),
                Url = "https://websolutions.com/careers/4"
            }
        };

        return Task.FromResult<IEnumerable<JobPost>>(jobs);
    }
}