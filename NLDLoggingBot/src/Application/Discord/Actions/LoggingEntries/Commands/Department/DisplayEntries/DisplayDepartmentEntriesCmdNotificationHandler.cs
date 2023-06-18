using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using MediatR;

namespace Application.Discord.Actions.LoggingEntries.Commands.Department.DisplayEntries;

internal class DisplayDepartmentEntriesCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<GetDepartmentEntriesCmdNotification>
{
    public DisplayDepartmentEntriesCmdNotificationHandler(IDepartmentService departmentService,
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

    public async Task Handle(GetDepartmentEntriesCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            (var department, bool foundDept) = await GetDepartmentAsync(notification.Context, cancellationToken);

            if (!foundDept)
            {
                return;
            }

            var users = await _userService.GetUsersWithDepartmentLogsAsync(department.Id, cancellationToken);

            if (!users.Any())
            {
                await socket.FollowupAsync(embed: _embedCollection.NoDepartmentLogsFound(department.Name));
                return;
            }

            var loggingEntries = await _entriesService.GetAllForDepartmentAsync(department.Id, cancellationToken);
            var rangeButtons = _componentService.CreateUpdateSelectMenuRangeButtons(users.Count);
            var usersSelectmenu = _componentService.CreateDisplayDepartmentLogsSelectMenuAsync(notification.Context, users, 0);

            var componentBuilder = new ComponentBuilder()
                .WithSelectMenu(usersSelectmenu);

            rangeButtons.ForEach(rangeButton => componentBuilder.WithButton(rangeButton));

            await socket.FollowupAsync(embed: _embedCollection.GetDisplayDepartmentLogsTotalEmbed(department, loggingEntries), components: componentBuilder.Build());
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }
    }
}
