using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;

namespace Application.Discord.Actions.DepartmentDiscords.Commands.DeleteDepartmentDiscord;

internal class DeleteDepartmentDiscordCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<DeleteDepartmentDiscordCmdNotification>
{
    public DeleteDepartmentDiscordCmdNotificationHandler(IDepartmentService departmentService,
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

    public async Task Handle(DeleteDepartmentDiscordCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;

        await socket.DeferAsync();

        try
        {
            var success = await _departmentDiscordService.DeleteByGuildIdAsync(notification.Context.Guild.Id, cancellationToken);

            if (!success)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoDepartmentFound());
                return;
            }

            await socket.FollowupAsync(embed: _embedCollection.DepartmentDiscordRemoved());
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed());
        }

        return;
    }
}
