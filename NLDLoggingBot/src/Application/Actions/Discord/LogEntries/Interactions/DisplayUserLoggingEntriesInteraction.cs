using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces;
using Application.Common.Models;
using Discord.Interactions;
using Discord;
using Domain.Enums;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Interactions;

public record DisplayUserLoggingEntriesInteraction : IRequest<Unit>
{
    public ulong DiscordUserId { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class DisplayUserLoggingEntriesInteractionHandler : MediatRDiscordActionsBase, IRequestHandler<DisplayUserLoggingEntriesInteraction, Unit>
{
    public DisplayUserLoggingEntriesInteractionHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(DisplayUserLoggingEntriesInteraction request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            var user = await _userService.GetByDiscordIdAsync(request.DiscordUserId, cancellationToken);

            if (user == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoUserFound(request.DiscordUserId), ephemeral: true);
                return Unit.Value;
            }

            (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

            if (!foundDept)
            {
                return Unit.Value;
            }

            var robloxUser = await _robloxUserService.GetFullUserAsync(user.RobloxId.ToString(), cancellationToken);

            if (await _entriesService.GetUserCountAsync(department.Id, user.Id, cancellationToken) <= 0)
            {
                await socket.FollowupAsync(embed: _embedCollection.NoLogsFound(user.DiscordId.Value), ephemeral: true);
                return Unit.Value;
            }

            var loggingEntries = await _entriesService.GetAllForUserAsync(department.Id, user.Id, cancellationToken);

            var logsSelectmenu = _componentService.CreateDisplayLogsSelectMenuAsync(loggingEntries, 0);
            var rangeButtons = _componentService.CreateUpdateSelectMenuRangeButtons(loggingEntries.Count, user.DiscordId.Value);
            var componentBuilder = new ComponentBuilder()
                .WithSelectMenu(logsSelectmenu);

            rangeButtons.ForEach(rangeButton => componentBuilder.WithButton(rangeButton));

            await socket.FollowupAsync(embed: _embedCollection.GetDisplayLogsTotalEmbed(robloxUser, loggingEntries), components: componentBuilder.Build(), ephemeral: true);
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }

        return Unit.Value;
    }
}
