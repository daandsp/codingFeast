using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Commands;

public record DisplayUserLoggingEntriesCommand : IRequest<Unit>
{
    public IUser User { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class DisplayUserLoggingEntriesCommandHandler : MediatRDiscordActionsBase, IRequestHandler<DisplayUserLoggingEntriesCommand, Unit>
{
    public DisplayUserLoggingEntriesCommandHandler(IDepartmentService departmentService,
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
    {
    }

    public async Task<Unit> Handle(DisplayUserLoggingEntriesCommand request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            var user = await _userService.GetByDiscordIdAsync(request.User.Id, cancellationToken);

            if (user == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoUserFound(request.User.Id));
                return Unit.Value;
            }

            (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

            if (!foundDept)
            {
                return Unit.Value;
            }

            var robloxUser = await _robloxUserService.GetFullUserAsync(user.RobloxId.ToString(), cancellationToken);

            var logCount = await _entriesService.GetUserCountAsync(department.Id, user.Id, cancellationToken);

            if (logCount <= 0)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoLogsFound(user.DiscordId.Value));
                return Unit.Value;
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

        return Unit.Value;
    }
}