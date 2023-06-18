using Application.Common.Models;
using Discord.Interactions;

namespace Application.Discord.Actions.LoggingEntries.Commands.Department.DeleteEntries;

public class DeleteDepartmentEntriesCmdNotification : BaseNotification
{
    public DeleteDepartmentEntriesCmdNotification(SocketInteractionContext context) 
        : base(context)
    { }
}
