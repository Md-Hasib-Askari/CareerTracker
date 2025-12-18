public class NotificationLog
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? JobMatchId { get; set; }
    public NotificationChannel ChannelType { get; set; }
    public DateTime SentAt { get; set; }
    public string PayloadSummary { get; set; } = string.Empty;

    public User User { get; set; } = default!;
    public JobMatch? JobMatch { get; set; }
}
