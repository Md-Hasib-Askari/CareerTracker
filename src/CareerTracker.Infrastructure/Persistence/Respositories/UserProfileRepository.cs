
using Microsoft.EntityFrameworkCore;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly CareerTrackerDbContext _dbContext;

    public UserProfileRepository(CareerTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserProfile?> GetByUserIdAsync(Guid userId, CancellationToken ct)
    {
        var profile = await _dbContext.UserProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(up => up.UserId == userId, ct);

        return profile;
    }

    public Task UpsertAsync(UserProfile profile, CancellationToken ct)
    {
        _dbContext.UserProfiles.Update(profile);
        return _dbContext.SaveChangesAsync(ct);
    }
}