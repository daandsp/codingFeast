using Application.Common.Models;
using Discord.Interactions;
using Domain.Enums;

namespace Application.Discord.Actions.DepartmentDiscords.Commands.ConfigureDepartmentDiscord;

public class ConfigureDepartmentDiscordCmdNotification : BaseNotification
{
    public int DepartmentId { get; set; }
    public Permissions Permissions { get; set; }

    public ConfigureDepartmentDiscordCmdNotification(int departmentId, Permissions permissions, SocketInteractionContext context) 
        : base(context)
    {
        DepartmentId = departmentId;
        Permissions = permissions;
    }
}
