using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Interactions;

public record DisplayDepartmentUserLoggingEntriesTotalByDiscordIdInteraction : IRequest<Unit>
{
    public string DiscordUserId { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class DisplayDepartmentUserLoggingEntriesTotalByDiscordIdInteractionHandler : MediatRDiscordActionsBase, IRequestHandler<DisplayDepartmentUserLoggingEntriesTotalByDiscordIdInteraction, Unit>
{
    public DisplayDepartmentUserLoggingEntriesTotalByDiscordIdInteractionHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(DisplayDepartmentUserLoggingEntriesTotalByDiscordIdInteraction request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            var user = await _userService.GetByDiscordIdAsync(Convert.ToUInt64(request.DiscordUserId), cancellationToken);

            if (user == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.NotFoundEmbed(), ephemeral: true);
                return Unit.Value;
            }

            (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

            if (!foundDept)
            {
                return Unit.Value;
            }

            var loggingEntries = await _entriesService.GetAllForUserAsync(department.Id, user.Id, cancellationToken);

            if (!loggingEntries.Any())
            {
                await socket.FollowupAsync(embed: _embedCollection.NotFoundEmbed(), ephemeral: true);
                return Unit.Value;
            }

            var robloxUser = await _robloxUserService.GetFullUserAsync(user.RobloxId.ToString(), cancellationToken);

            var displayLogsButton = _componentService.CreateShowUserLogsButton(user.DiscordId.Value);

            var componentBuilder = new ComponentBuilder()
                .WithButton(displayLogsButton)
                .Build();

            await socket.FollowupAsync(embed: _embedCollection.GetDisplayLogsTotalEmbed(robloxUser, loggingEntries), components: componentBuilder, ephemeral: true);
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }

        return Unit.Value;
    }
}
