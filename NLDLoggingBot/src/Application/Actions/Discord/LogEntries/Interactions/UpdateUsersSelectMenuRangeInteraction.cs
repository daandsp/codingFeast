using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Interactions;

public record UpdateUsersSelectMenuRangeInteraction : IRequest<Unit>
{
    public int Skip { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class UpdateUsersSelectMenuRangeInteractionHandler : MediatRDiscordActionsBase, IRequestHandler<UpdateUsersSelectMenuRangeInteraction, Unit>
{
    public UpdateUsersSelectMenuRangeInteractionHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(UpdateUsersSelectMenuRangeInteraction request, CancellationToken cancellationToken)
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

            (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

            if (!foundDept)
            {
                return Unit.Value;
            }

            var users = await _userService.GetUsersWithDepartmentLogsAsync(department.Id, cancellationToken);

            if (!users.Any())
            {
                await socket.FollowupAsync(embed: _embedCollection.NoDepartmentLogsFound(department.Name));
                return Unit.Value;
            }

            users = users.OrderBy(user => user.Id).ToList();
            var rangeButtons = _componentService.CreateUpdateSelectMenuRangeButtons(users.Count);
            var usersSelectmenu = _componentService.CreateDisplayDepartmentLogsSelectMenuAsync(request.Context, users, request.Skip);

            var componentBuilder = new ComponentBuilder()
                .WithSelectMenu(usersSelectmenu);

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
