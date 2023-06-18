using Application.Common.Models;
using Discord.Interactions;

namespace Application.Discord.Actions.Users.Commands.VerifyRobloxId;

public class VerifyUserCmdNotification : BaseNotification
{
    public VerifyUserCmdNotification(SocketInteractionContext context)
        : base(context)
    { }
}
