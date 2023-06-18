using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using MediatR;

namespace Application.Discord.Actions.LoggingEntries.Commands.Users.DisplayEntries;

internal class GetUserEntriesCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<GetUserEntriesCmdNotification>
{
    public GetUserEntriesCmdNotificationHandler(IDepartmentService departmentService, 
        IDepartmentGuildService departmentDiscordService, 
        IUserService userService,
        ILoggingEntriesService entriesService, 
        IEmbedCollection embedCollection, 
        IBloxLinkApiService bloxLinkApiService, 
        IRobloxUserApiService robloxUserApiService, 
        IComponentService componentService) 
        : base(departmentService, 
            departmentDiscordService, 
            userService, entriesService, 
            embedCollection, 
            bloxLinkApiService, 
            robloxUserApiService, 
            componentService)
    { }

    public async Task Handle(GetUserEntriesCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            var user = await _userService.GetByDiscordIdAsync(notification.User.Id, cancellationToken);

            if (user == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoUserFound(notification.User.Id));
                return;
            }

            (var department, bool foundDept) = await GetDepartmentAsync(notification.Context, cancellationToken);

            if (!foundDept)
            {
                return;
            }

            var robloxUser = await _robloxUserService.GetFullUserAsync(user.RobloxId.ToString(), cancellationToken);

            var logCount = await _entriesService.GetUserCountAsync(department.Id, user.Id, cancellationToken);

            if (logCount <= 0)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoLogsFound(user.DiscordId.Value));
                return;
            }

            var loggingEntries = await _entriesService.GetAllForUserAsync(department.Id, user.Id, cancellationToken);
            var rangeButtons = _componentService.CreateUpdateSelectMenuRangeButtons(logCount, user.DiscordId.Value);
            var logsSelectmenu = _componentService.CreateDisplayLogsSelectMenuAsync(loggingEntries, 0);

            var componentBuilder = new ComponentBuilder()
                .WithSelectMenu(logsSelectmenu);

            rangeButtons.ForEach(rangeButton => componentBuilder.WithButton(rangeButton));

            await socket.FollowupAsync(embed: _embedCollection.GetDisplayLogsTotalEmbed(robloxUser, loggingEntries), components: componentBuilder.Build());
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }
    }
}
