public sealed class PageFilter
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 20;

    public int Skip => (Page - 1) * PageSize;
    public string SearchTerm { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
    public string RemoteType { get; init; } = string.Empty;
    public string EmploymentType { get; init; } = string.Empty;
}
