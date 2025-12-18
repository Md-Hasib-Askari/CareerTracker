public class NotificationSettings
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public bool EmailEnabled { get; set; }
    public bool TelegramEnabled { get; set; }
    public string? TelegramChatId { get; set; }
    public NotificationFrequency Frequency { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; } = default!;
}
