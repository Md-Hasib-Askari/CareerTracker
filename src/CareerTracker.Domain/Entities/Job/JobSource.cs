public class JobSource
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string BaseUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
