using CareerTracker.Application.Features.Jobs.Commands;
using CareerTracker.Application.Features.Jobs.DTOs;

public interface IJobPostService
{
    Task<JobPostDto?> GetJobByIdAsync(int id, CancellationToken ct);
    Task<JobPostDto> CreateJobAsync(JobPostCreateCommand jobCreateDto, CancellationToken ct);
    Task<IEnumerable<JobPostDto>> GetAllJobsAsync(PageFilter? filter, CancellationToken ct);
}