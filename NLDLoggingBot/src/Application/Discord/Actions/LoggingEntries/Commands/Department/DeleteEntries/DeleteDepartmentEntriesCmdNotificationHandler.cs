using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using MediatR;

namespace Application.Discord.Actions.LoggingEntries.Commands.Department.DeleteEntries;

internal class DeleteDepartmentEntriesCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<DeleteDepartmentEntriesCmdNotification>
{
    public DeleteDepartmentEntriesCmdNotificationHandler(IDepartmentService departmentService,
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

    public async Task Handle(DeleteDepartmentEntriesCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;

        await socket.DeferAsync();
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

            var loggingEntries =
                await _entriesService.GetAllForDepartmentAsync(department.Id, cancellationToken);

            await _entriesService.DeleteListAsync(loggingEntries, cancellationToken);

            await socket.FollowupAsync(embed: _embedCollection.DeletedDepartmentLogs(department.Name));

            try
            {
                foreach (var guildUser in users.Select(user => notification.Context.Guild.GetUser(user.DiscordId.Value)).Where(guildUser => guildUser != null))
                {
                    try
                    {
                        await guildUser.SendMessageAsync(
                            $"Your logs were wiped in {department.Name} by <@{notification.Context.User.Id}>.");
                    }
                    catch { }
                }
            }
            catch { }

        }
        catch
        {
            await socket.RespondAsync(embed: _embedCollection.ErrorEmbed());
        }
    }
}
