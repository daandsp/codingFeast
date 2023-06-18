using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using Domain.Enums;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Interactions;

public record UpdateLogsSelectMenuRangeInteraction : IRequest<Unit>
{
    public int Skip { get; set; }
    public ulong DiscordUserId { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class UpdateLogsSelectMenuRangeInteractionHandler : MediatRDiscordActionsBase, IRequestHandler<UpdateLogsSelectMenuRangeInteraction, Unit>
{
    public UpdateLogsSelectMenuRangeInteractionHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(UpdateLogsSelectMenuRangeInteraction request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
            var response = await request.Context.Interaction.GetOriginalResponseAsync();

            if (response == null)
            {
                await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed());
                return Unit.Value;
            }

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

            var loggingEntries = await _entriesService.GetAllForUserAsync(department.Id, user.Id, cancellationToken);

            var logsSelectmenu = _componentService.CreateDisplayLogsSelectMenuAsync(loggingEntries, request.Skip);
            var rangeButtons = _componentService.CreateUpdateSelectMenuRangeButtons(loggingEntries.Count, user.DiscordId.Value);
            var componentBuilder = new ComponentBuilder()
                .WithSelectMenu(logsSelectmenu);

            rangeButtons.ForEach(rangeButton => componentBuilder.WithButton(rangeButton));

            await response.ModifyAsync(properties =>
            {
                properties.Components = componentBuilder.Build();
            });
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }

        return Unit.Value;
    }
}

