using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Interactions;

public record DisplayUserLogEntryInteraction : IRequest<Unit>
{
    public string EntryId { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class DisplayUserLogEntryInteractionHandler : MediatRDiscordActionsBase, IRequestHandler<DisplayUserLogEntryInteraction, Unit>
{
    public DisplayUserLogEntryInteractionHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(DisplayUserLogEntryInteraction request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            var user = await _userService.GetByLoggingEntryIdAsync(Convert.ToInt32(request.EntryId), cancellationToken);

            if (user == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.NotFoundEmbed(), ephemeral: true);
                return Unit.Value;
            }

            var robloxUser = await _robloxUserService.GetFullUserAsync(user.RobloxId.ToString(), cancellationToken);

            var entry = await _entriesService.GetSingleAsync(Convert.ToInt32(request.EntryId), cancellationToken);

            if (entry == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.NotFoundEmbed(), ephemeral: true);
                return Unit.Value;
            }

            (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

            if (!foundDept)
            {
                return Unit.Value;
            }

            var logDeleteButton = _componentService.CreateDeleteLogButton(entry.Id);

            var componentBuilder = new ComponentBuilder()
                .WithButton(logDeleteButton)
                .Build();

            await socket.FollowupAsync(embed: _embedCollection.GetDisplayLogEmbed(robloxUser, entry), components: componentBuilder, ephemeral: true);
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }

        return Unit.Value;
    }
}
