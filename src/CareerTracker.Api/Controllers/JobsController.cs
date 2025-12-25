using CareerTracker.Application.Features.Jobs.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class JobsController : ControllerBase
{
    private readonly IJobPostService _jobService;
    private readonly ILogger<JobsController> _logger;

    public JobsController(IJobPostService jobService, ILogger<JobsController> logger)
    {
        _jobService = jobService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobs(PageFilter? filter)
    {
        _logger.LogInformation("Fetching all jobs with filter {@Filter}", filter);
        var job = await _jobService.GetAllJobsAsync(filter, CancellationToken.None);
        if (job == null)
        {
            return NotFound();
        }
        return Ok(job);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobPostById(int id, CancellationToken ct)
    {
        var job = await _jobService.GetJobByIdAsync(id, ct);
        if (job == null)
        {
            return NotFound();
        }
        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJobPost(JobPostCreateCommand jobCreateDto, CancellationToken ct)
    {
        var job = await _jobService.CreateJobAsync(jobCreateDto, ct);
        return CreatedAtAction(nameof(GetJobPostById), new { id = job.Id }, job);
    }
}