using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using MediatR;

namespace Application.Discord.Actions.LoggingEntries.Commands.Users.DeleteEntries;

internal class DeleteUserEntriesCmdNotificationHandler : MediatRDiscordActionsBase, INotificationHandler<DeleteUserEntriesCmdNotification>
{
    public DeleteUserEntriesCmdNotificationHandler(IDepartmentService departmentService, 
        IDepartmentGuildService departmentDiscordService, 
        IUserService userService, ILoggingEntriesService entriesService, 
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

    public async Task Handle(DeleteUserEntriesCmdNotification notification, CancellationToken cancellationToken)
    {
        var socket = notification.Context.Interaction;

        await socket.DeferAsync();
        try
        {
            (var user, bool foundUser) = await GetUserAsync(notification.Context, cancellationToken);
            (var department, bool foundDept) = await GetDepartmentAsync(notification.Context, cancellationToken);

            if (!foundUser || !foundDept)
            {
                return;
            }

            var loggingEntries =
                await _entriesService.GetAllForUserAsync(department!.Id, user!.Id, cancellationToken);

            if (!loggingEntries.Any())
            {
                await socket.FollowupAsync(embed: _embedCollection.NoLogsFound(notification.User.Id));
                return;
            }

            await _entriesService.DeleteListAsync(loggingEntries, cancellationToken);

            await socket.FollowupAsync(embed: _embedCollection.DeletedLogs(notification.User.Id, loggingEntries.Count));

            try
            {
                await notification.User.SendMessageAsync(
                    $"Your logs were wiped in {department.Name} by <@{notification.Context.User.Id}>.");
            }
            catch { }
        }
        catch
        {
            await socket.RespondAsync(embed: _embedCollection.ErrorEmbed());
        }
    }
}
