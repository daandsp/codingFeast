using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Discord.Actions.LoggingEntries.Commands.Users.CreateEntry;

internal class SaveEntryCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<CreateEntryCmdNotification>
{
    public SaveEntryCmdNotificationHandler(IDepartmentService departmentService,
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

    public async Task Handle(CreateEntryCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;

        var x = notification.Context.Guild.CategoryChannels;

        if (notification.Hours > 23 || notification.Minutes > 59)
        {
            await socket.RespondAsync("You can not submit a log longer than 23h 59m.", ephemeral: true);
            return;
        }

        await socket.DeferAsync();

        try
        {
            (var user, bool success) = await GetUserAsync(notification.Context, cancellationToken);
            (var department, bool foundDept) = await GetDepartmentAsync(notification.Context, cancellationToken);

            if (!success || !foundDept)
            {
                return;
            }

            var timeSpan = TimeSpan.FromHours(notification.Hours) + TimeSpan.FromMinutes(notification.Minutes);

            var loggingEntry = await _entriesService.CreateAsync(new LoggingEntry(department!.Id, user!.Id, timeSpan), cancellationToken);
            var robloxUser = await _robloxUserService.GetFullUserAsync(Convert.ToString(user.RobloxId), cancellationToken);

            await socket.FollowupAsync(embed: _embedCollection.LoggingEntryAdded(robloxUser, loggingEntry, notification.Context.User.Id));
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed());
        }
    }
}
