public interface IUserProfileRepository
{
    Task<UserProfile?> GetByUserIdAsync(Guid userId, CancellationToken ct);
    Task UpsertAsync(UserProfile profile, CancellationToken ct);
}