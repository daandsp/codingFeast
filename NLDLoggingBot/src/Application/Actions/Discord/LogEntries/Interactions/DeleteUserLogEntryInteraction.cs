using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Interactions;

public record DeleteUserLogEntryInteraction : IRequest<Unit>
{
    public int EntryId { get; set; }
    public SocketInteractionContext Context { get; set; }
}

internal class DeleteUserLogEntryInteractionHandler : MediatRDiscordActionsBase, IRequestHandler<DeleteUserLogEntryInteraction, Unit>
{
    public DeleteUserLogEntryInteractionHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(DeleteUserLogEntryInteraction request, CancellationToken cancellationToken)
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

            if (!await _entriesService.DeleteSingleAsync(request.EntryId, cancellationToken))
            {
                await socket.FollowupAsync(embed: _embedCollection.NotFoundEmbed(), ephemeral: true);
                return Unit.Value;
            }

            var componentBuilder = new ComponentBuilder();

            await response.ModifyAsync(properties =>
            {
                properties.Embed = _embedCollection.DeletedLog();
                properties.Components = componentBuilder.Build();
            });

            //await socket.FollowupAsync(embed: _embedCollection.DeletedLog(), ephemeral: true);
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }

        return Unit.Value;
    }
}
