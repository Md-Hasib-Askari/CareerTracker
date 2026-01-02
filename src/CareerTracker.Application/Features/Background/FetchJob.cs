public class FetchJob : IFetchJob
{
    private readonly IJobSourceClient _jobSourceClient;

    public FetchJob(IJobSourceClient jobSourceClient)
    {
        _jobSourceClient = jobSourceClient;
    }

    public async Task<IEnumerable<JobPost>> ExecuteAsync(string? query, CancellationToken cancellationToken)
    {
        return await _jobSourceClient.FetchNewJobsAsync(query, cancellationToken);
    }
}