namespace Domain.Entities;

public class User : EntityBase
{
    public ulong? DiscordId { get; set; }
    public ulong RobloxId { get; set; }
    public DateTime LastVerified { get; private set; } = DateTime.Now;

    public List<LoggingEntry> LogEntries { get; set; } = new List<LoggingEntry>();


    public User() { }

    public void UpdateLastVerified()
    {
        LastVerified = DateTime.Now;
    }

    public bool RecentlyVerified()
    {
        return LastVerified.Date == DateTime.Today;
    }
}
