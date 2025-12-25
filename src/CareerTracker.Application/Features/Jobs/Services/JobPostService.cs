using CareerTracker.Application.Features.Jobs.Commands;
using CareerTracker.Application.Features.Jobs.DTOs;

public class JobPostService : IJobPostService
{
    private readonly IJobPostRepository _jobPostRepository;
    public JobPostService(IJobPostRepository jobPostRepository)
    {
        _jobPostRepository = jobPostRepository;
    }
    public Task<JobPostDto> CreateJobAsync(JobPostCreateCommand jobCreateDto, CancellationToken ct)
    {
        var jobs = _jobPostRepository.AddRangeAsync(new List<JobPost>
        {
            new JobPost
            {
                Id = Guid.NewGuid(),
                JobSourceId = jobCreateDto.JobSourceId,
                ExternalId =  jobCreateDto.ExternalId,
                Title = jobCreateDto.Title,
                CompanyName = jobCreateDto.CompanyName,
                Location = jobCreateDto.Location,
                RemoteType = Enum.Parse<RemoteType>(jobCreateDto.RemoteType.ToString()),
                EmploymentType = Enum.Parse<EmploymentType>(jobCreateDto.EmploymentType.ToString()),
                Description = jobCreateDto.Description,
                Url = jobCreateDto.Url,
                PostedAt = jobCreateDto.PostedAt,
                CollectedAt = jobCreateDto.CollectedAt,
                IsActive = true
            }
        }, ct);

        var jobsResult = jobs.Result.First();

        return Task.FromResult(new JobPostDto
        {
            Id = jobsResult.Id,
            JobSourceId = jobsResult.JobSourceId,
            ExternalId = jobsResult.ExternalId,
            Title = jobsResult.Title,
            CompanyName = jobsResult.CompanyName,
            Location = jobsResult.Location,
            RemoteType = jobsResult.RemoteType.ToString(),
            EmploymentType = jobsResult.EmploymentType.ToString(),
            Description = jobsResult.Description,
            Url = jobsResult.Url,
            PostedAt = jobsResult.PostedAt,
            CollectedAt = jobsResult.CollectedAt,
            IsActive = jobsResult.IsActive
        });
    }

    public async Task<IEnumerable<JobPostDto>> GetAllJobsAsync(PageFilter? filter, CancellationToken ct)
    {
        var jobPosts = await _jobPostRepository.GetPagedAsync(filter, ct);
        if (jobPosts == null || !jobPosts.Any())
        {
            return Enumerable.Empty<JobPostDto>();
        }
        return jobPosts.Select(jp => new JobPostDto
        {
            Id = jp.Id,
            Title = jp.Title,
            CompanyName = jp.CompanyName,
            Location = jp.Location,
            RemoteType = jp.RemoteType.ToString(),
            EmploymentType = jp.EmploymentType.ToString(),
            PostedAt = jp.PostedAt
        });
    }

    public async Task<JobPostDto?> GetJobByIdAsync(int id, CancellationToken ct)
    {
        var guid = new Guid(id.ToString());
        var jobPost = await _jobPostRepository.GetByIdAsync(guid, ct);
        if (jobPost == null)
        {
            return null;
        }

        return new JobPostDto
        {
            Id = jobPost.Id,
            JobSourceId = jobPost.JobSourceId,
            ExternalId = jobPost.ExternalId,
            Title = jobPost.Title,
            CompanyName = jobPost.CompanyName,
            Location = jobPost.Location,
            RemoteType = jobPost.RemoteType.ToString(),
            EmploymentType = jobPost.EmploymentType.ToString(),
            Description = jobPost.Description,
            Url = jobPost.Url,
            PostedAt = jobPost.PostedAt,
            CollectedAt = jobPost.CollectedAt,
            IsActive = jobPost.IsActive
        };
    }
}