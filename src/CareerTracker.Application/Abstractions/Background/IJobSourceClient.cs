public interface IJobSourceClient
{
    string SourceName { get; }
    Task<IEnumerable<JobPost>> FetchNewJobsAsync(string? query, CancellationToken cancellationToken);
}