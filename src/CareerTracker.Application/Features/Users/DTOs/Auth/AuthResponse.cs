public sealed record AuthResponse
{
    public required string Status { get; set; }
    public required string Message { get; set; }
    public string? Token { get; set; }
}