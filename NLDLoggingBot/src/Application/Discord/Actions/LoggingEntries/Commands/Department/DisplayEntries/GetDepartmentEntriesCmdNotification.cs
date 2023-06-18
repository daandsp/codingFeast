using Application.Common.Models;
using Discord.Interactions;

namespace Application.Discord.Actions.LoggingEntries.Commands.Department.DisplayEntries;

public class GetDepartmentEntriesCmdNotification : BaseNotification
{
    public GetDepartmentEntriesCmdNotification(SocketInteractionContext context) 
        : base(context)
    { }
}
