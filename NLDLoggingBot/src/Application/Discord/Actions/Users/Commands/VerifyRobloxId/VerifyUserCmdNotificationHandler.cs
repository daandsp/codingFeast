using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Discord.Actions.Users.Commands.VerifyRobloxId;

internal class VerifyUserCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<VerifyUserCmdNotification>
{
    public VerifyUserCmdNotificationHandler(IDepartmentService departmentService,
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

    public async Task Handle(VerifyUserCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            (User user, bool found) = await GetUserAsync(notification.Context, cancellationToken);

            if (!found)
            {
                return;
            }

            if (user.RecentlyVerified())
            {
                await socket.FollowupAsync(embed: _embedCollection.RecentlyVerified());
                return;
            }

            var bloxLinkUser = await _bloxLinkService.GetRobloxIdByDiscordIdAsync(notification.Context.User.Id, cancellationToken);

            if (bloxLinkUser == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoBloxLinkResult());
                return;
            }

            user.RobloxId = Convert.ToUInt64(bloxLinkUser.robloxId);
            user.UpdateLastVerified();
            var success = await _userService.UpdateAsync(user, cancellationToken);

            if (!success)
            {
                await socket.FollowupAsync(embed: _embedCollection.FailedToUpdateUser());
                return;
            }

            await socket.FollowupAsync(embed: _embedCollection.UpdatedUser());
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }
    }
}
