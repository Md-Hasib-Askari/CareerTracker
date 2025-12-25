public interface IJobPostRepository
{
    Task<JobPost?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<JobPost>> AddRangeAsync(IEnumerable<JobPost> jobPosts, CancellationToken ct);
    Task<IEnumerable<JobPost>> GetNewPostsSinceAsync(DateTime since, CancellationToken ct);
    Task<IEnumerable<JobPost>> GetPagedAsync(PageFilter? filter, CancellationToken ct);
}