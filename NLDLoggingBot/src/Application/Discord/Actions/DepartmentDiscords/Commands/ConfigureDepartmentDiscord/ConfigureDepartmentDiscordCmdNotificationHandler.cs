using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Discord.Actions.DepartmentDiscords.Commands.ConfigureDepartmentDiscord;

internal class ConfigureDepartmentDiscordCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<ConfigureDepartmentDiscordCmdNotification>
{
    public ConfigureDepartmentDiscordCmdNotificationHandler(IDepartmentService departmentService,
        IDepartmentGuildService departmentDiscordService,
        IUserService userService,
        ILoggingEntriesService entriesService,
        IEmbedCollection embedCollection,
        IBloxLinkApiService bloxLinkApiService,
        IRobloxUserApiService robloxUserApiService,
        IComponentService componentService)
        : base(departmentService,
            departmentDiscordService,
            userService,
            entriesService,
            embedCollection,
            bloxLinkApiService,
            robloxUserApiService,
            componentService)
    { }

    public async Task Handle(ConfigureDepartmentDiscordCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;
        await socket.DeferAsync();

        try
        {
            var existingDiscord = await _departmentDiscordService.GetByGuildIdAsync(notification.Context.Guild.Id, cancellationToken);

            if (existingDiscord?.Department.Id == notification.DepartmentId)
            {
                await socket.FollowupAsync(embed: _embedCollection.DepartmentDiscordNotChanged());
                return;
            }

            if (existingDiscord != null)
            {
                await socket.FollowupAsync(embed: _embedCollection.DepartmentDiscordAlreadyExists());
                return;
            }

            var department = await _departmentService.GetByIdAsync(notification.DepartmentId, cancellationToken);
            var existingprimaryDiscord = await _departmentDiscordService.GetPrimaryByDepartmentId(department.Id, cancellationToken);

            if (existingprimaryDiscord != null && notification.Permissions == Permissions.FullAccess)
            {
                await socket.FollowupAsync(embed: _embedCollection.PrimaryDepartmentDiscordAlreadyExists());
                return;
            }

            var newDiscord = await _departmentDiscordService.CreateAsync(
            new DepartmentGuild(notification.Context.Guild.Id, notification.DepartmentId, notification.Permissions), cancellationToken);
            var discord = await _departmentDiscordService.GetByIdAsync(newDiscord.Id, cancellationToken);

            await socket.FollowupAsync(embed: _embedCollection.DepartmentDiscordAdded(discord));
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed());
        }
    }
}
