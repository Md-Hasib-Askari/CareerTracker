using CareerTracker.Application.Profiles.Dtos;

public record CreateProfileCommand
{
    public Guid UserId { get; init; }
    public ProfileDto ProfileDto { get; init; } = default!;
}