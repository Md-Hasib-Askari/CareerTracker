public sealed record RegisterRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Password2 { get; set; }
}