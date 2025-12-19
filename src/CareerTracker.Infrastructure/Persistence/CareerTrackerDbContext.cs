using Microsoft.EntityFrameworkCore;

public class CareerTrackerDbContext : DbContext
{
    public CareerTrackerDbContext(DbContextOptions<CareerTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<JobSource> JobSources => Set<JobSource>();
    public DbSet<JobPost> JobPosts => Set<JobPost>();
    public DbSet<JobMatch> JobMatches => Set<JobMatch>();
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<NotificationSettings> NotificationSettings => Set<NotificationSettings>();
    public DbSet<NotificationLog> NotificationLogs => Set<NotificationLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.NotificationSettings)
            .WithOne(ns => ns.User)
            .HasForeignKey<NotificationSettings>(ns => ns.UserId);

        modelBuilder.Entity<JobPost>()
            .HasOne(jp => jp.JobSource)
            .WithMany(js => js.JobPosts)
            .HasForeignKey(jp => jp.JobSourceId);

        modelBuilder.Entity<JobMatch>()
            .HasOne(jm => jm.User)
            .WithMany(u => u.JobMatches)
            .HasForeignKey(jm => jm.UserId);

        modelBuilder.Entity<JobMatch>()
            .HasOne(jm => jm.JobPost)
            .WithMany(jp => jp.JobMatches)
            .HasForeignKey(jm => jm.JobPostId);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.User)
            .WithMany(u => u.Applications)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.JobPost)
            .WithMany(jp => jp.Applications)
            .HasForeignKey(a => a.JobPostId);

        modelBuilder.Entity<NotificationLog>()
            .HasOne(nl => nl.User)
            .WithMany()
            .HasForeignKey(nl => nl.UserId);

        modelBuilder.Entity<NotificationLog>()
            .HasOne(nl => nl.JobMatch)
            .WithMany()
            .HasForeignKey(nl => nl.JobMatchId);

        base.OnModelCreating(modelBuilder);
    }

}