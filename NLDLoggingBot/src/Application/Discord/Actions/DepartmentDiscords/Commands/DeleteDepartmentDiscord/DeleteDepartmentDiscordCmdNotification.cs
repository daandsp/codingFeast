using Application.Common.Models;
using Discord.Interactions;

namespace Application.Discord.Actions.DepartmentDiscords.Commands.DeleteDepartmentDiscord;

public class DeleteDepartmentDiscordCmdNotification : BaseNotification
{
    public DeleteDepartmentDiscordCmdNotification(SocketInteractionContext context) 
        : base(context)
    { }
}
