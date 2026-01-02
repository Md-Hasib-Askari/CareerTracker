using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register repositories
        // User
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserProfileRepository, UserProfileRepository>();

        // Job Post
        services.AddScoped<IJobPostRepository, JobPostRepository>();
        // Add other infrastructure services here

        // Background services
        services.AddScoped<IJobSourceClient, FakeJobSourceClient>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
    {
        services.AddDbContext<CareerTrackerDbContext>(optionsAction);
        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services
        // User
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IAuthService, AuthService>();

        // Job Post
        services.AddScoped<IJobPostService, JobPostService>();
        // Add other application services here

        // Background services
        services.AddScoped<IFetchJob, FetchJob>();

        return services;
    }

}