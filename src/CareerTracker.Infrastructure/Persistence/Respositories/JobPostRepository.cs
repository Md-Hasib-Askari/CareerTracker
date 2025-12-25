using Microsoft.EntityFrameworkCore;

public class JobPostRepository : IJobPostRepository
{
    private readonly CareerTrackerDbContext _dbContext;

    public JobPostRepository(CareerTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<JobPost?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _dbContext.JobPosts.FindAsync([id], ct);
    }

    public async Task<IEnumerable<JobPost>> AddRangeAsync(IEnumerable<JobPost> jobPosts, CancellationToken ct)
    {
        await _dbContext.JobPosts.AddRangeAsync(jobPosts, ct);
        await _dbContext.SaveChangesAsync(ct);
        return jobPosts;
    }

    public async Task<IEnumerable<JobPost>> GetNewPostsSinceAsync(DateTime since, CancellationToken ct)
    {
        return await _dbContext.JobPosts
            .Where(jp => jp.PostedAt >= since)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<JobPost>> GetPagedAsync(PageFilter? filter, CancellationToken ct)
    {
        var query = _dbContext.JobPosts.AsQueryable();

        // Filer by Search
        if (!string.IsNullOrWhiteSpace(filter?.SearchTerm))
        {
            query = query.Where(jp => jp.Title.Contains(filter.SearchTerm) || jp.CompanyName.Contains(filter.SearchTerm));
        }

        // Filter by Location
        if (!string.IsNullOrWhiteSpace(filter?.Location))
        {
            query = query.Where(jp => jp.Location.Contains(filter.Location));
        }

        // Filter by RemoteType
        if (!string.IsNullOrWhiteSpace(filter?.RemoteType))
        {
            query = query.Where(jp => jp.RemoteType.ToString() == filter.RemoteType);
        }

        // Filter by EmploymentType
        if (!string.IsNullOrWhiteSpace(filter?.EmploymentType))
        {
            query = query.Where(jp => jp.EmploymentType.ToString() == filter.EmploymentType);
        }

        return await query
            .Skip(filter?.Skip ?? 0)
            .Take(filter?.PageSize ?? 20)
            .ToListAsync(ct);
    }
}