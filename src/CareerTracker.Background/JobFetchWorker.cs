public class JobFetchWorker : BackgroundService
{
    private readonly IFetchJob _fetchJob;
    private readonly ILogger<JobFetchWorker> _logger;

    public JobFetchWorker(IFetchJob fetchJob, ILogger<JobFetchWorker> logger)
    {
        _fetchJob = fetchJob;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Job Fetch Worker running at: {time}", DateTimeOffset.Now);

        while (!stoppingToken.IsCancellationRequested)
        {
            var jobs = await _fetchJob.ExecuteAsync(null, stoppingToken);
            _logger.LogInformation("Fetched {count} new jobs at: {time}", jobs.Count(), DateTimeOffset.Now);

            // Wait for a specified interval before fetching again
            await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
        }
    }
}