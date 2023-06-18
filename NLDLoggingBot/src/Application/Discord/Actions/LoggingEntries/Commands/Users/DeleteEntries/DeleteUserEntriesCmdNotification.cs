using Application.Common.Models;
using Discord;
using Discord.Interactions;

namespace Application.Discord.Actions.LoggingEntries.Commands.Users.DeleteEntries;

public class DeleteUserEntriesCmdNotification : BaseNotification
{
    public IUser User { get; set; }

    public DeleteUserEntriesCmdNotification(IUser user, SocketInteractionContext context) 
        : base(context)
    {
        User = user;
    }
}
