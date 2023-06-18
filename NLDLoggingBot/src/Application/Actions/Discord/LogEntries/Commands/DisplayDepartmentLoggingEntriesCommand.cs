using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Domain.Enums;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Commands;

public record DisplayDepartmentLoggingEntriesCommand : IRequest<Unit>
{
    public SocketInteractionContext Context { get; set; }
}

public class DisplayDepartmentLoggingEntriesCommandHandler : MediatRDiscordActionsBase, IRequestHandler<DisplayDepartmentLoggingEntriesCommand, Unit>
{
    public DisplayDepartmentLoggingEntriesCommandHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(DisplayDepartmentLoggingEntriesCommand request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;
        await socket.DeferAsync(ephemeral: true);

        try
        {
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

            var loggingEntries = await _entriesService.GetAllForDepartmentAsync(department.Id, cancellationToken);
            var rangeButtons = _componentService.CreateUpdateSelectMenuRangeButtons(users.Count);
            var usersSelectmenu = _componentService.CreateDisplayDepartmentLogsSelectMenuAsync(request.Context, users, 0);

            var componentBuilder = new ComponentBuilder()
                .WithSelectMenu(usersSelectmenu);

            rangeButtons.ForEach(rangeButton => componentBuilder.WithButton(rangeButton));

            await socket.FollowupAsync(embed: _embedCollection.GetDisplayDepartmentLogsTotalEmbed(department, loggingEntries), components: componentBuilder.Build());
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed(), ephemeral: true);
        }

        return Unit.Value;
    }
}