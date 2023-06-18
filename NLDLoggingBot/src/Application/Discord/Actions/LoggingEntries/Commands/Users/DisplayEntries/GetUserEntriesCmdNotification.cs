using Application.Common.Models;
using Discord;
using Discord.Interactions;

namespace Application.Discord.Actions.LoggingEntries.Commands.Users.DisplayEntries;

public class GetUserEntriesCmdNotification : BaseNotification
{
    public IUser User { get; set; }

    public GetUserEntriesCmdNotification(IUser user, SocketInteractionContext context) 
        : base(context)
    {
        User = user;
    }
}
