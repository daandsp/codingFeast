using Application.Common.Models;
using Discord.Interactions;

namespace Application.Discord.Actions.LoggingEntries.Commands.Users.CreateEntry;

public class CreateEntryCmdNotification : BaseNotification
{
    public int Hours { get; set; }
    public int Minutes { get; set; }

    public CreateEntryCmdNotification(int hours, int minutes, SocketInteractionContext context)
        : base(context)
    {
        Hours = hours;
        Minutes = minutes;
    }
}
