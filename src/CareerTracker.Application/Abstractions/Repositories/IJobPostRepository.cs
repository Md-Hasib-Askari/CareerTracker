public interface IJobPostRepository
{
    Task<JobPost?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddRangeAsync(IEnumerable<JobPost> jobPosts, CancellationToken ct);
    Task<IEnumerable<JobPost>> GetNewPostsSinceAsync(DateTime since, CancellationToken ct);
}