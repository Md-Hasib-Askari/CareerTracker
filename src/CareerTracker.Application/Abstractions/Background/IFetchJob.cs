public interface IFetchJob
{
    Task<IEnumerable<JobPost>> ExecuteAsync(string? query, CancellationToken cancellationToken);
}