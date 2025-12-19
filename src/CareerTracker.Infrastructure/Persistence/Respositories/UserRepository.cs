
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{

    private readonly CareerTrackerDbContext _dbContext;
    public UserRepository(CareerTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> AddAsync(User user, CancellationToken ct)
    {
        var AddedUser = await _dbContext.Users.AddAsync(user, ct);
        await _dbContext.SaveChangesAsync(ct);
        return AddedUser.Entity;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, ct);
    }
}