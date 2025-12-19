public interface IJobMatchRepository
{
    Task CreateMatchesAsync(IEnumerable<JobMatch> jobMatches, CancellationToken cancellationToken);
    Task<IEnumerable<JobMatch>> GetUnnotifiedMatchesAsync(
        NotificationFrequency frequency,
        CancellationToken ct
    );
}