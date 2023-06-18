using Application.Common.Interfaces;
using Application.Common.Models;
using Discord.Interactions;
using Domain.Entities;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Commands;

public record CreateLoggingEntryCommand : IRequest<Unit>
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class CreateLoggingEntryCommandHandler : MediatRDiscordActionsBase, IRequestHandler<CreateLoggingEntryCommand, Unit>
{
    public CreateLoggingEntryCommandHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(CreateLoggingEntryCommand request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;

        if (request.Hours > 23 || request.Minutes > 59)
        {
            await socket.RespondAsync("You can not submit a log longer than 23h 59m.", ephemeral: true);
            return Unit.Value;
        }

        await socket.DeferAsync();

        try
        {
            (var user, bool foundUser) = await GetUserAsync(request.Context, cancellationToken);
            (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

            if (!foundUser || !foundDept)
            {
                return Unit.Value;
            }

            var timeSpan = TimeSpan.FromHours(request.Hours) + TimeSpan.FromMinutes(request.Minutes);

            var loggingEntry = await _entriesService.CreateAsync(new LoggingEntry(department.Id, user.Id, timeSpan), cancellationToken);
            var robloxUser = await _robloxUserService.GetFullUserAsync(Convert.ToString(user.RobloxId), cancellationToken);

            await socket.FollowupAsync(embed: _embedCollection.LoggingEntryAdded(robloxUser, loggingEntry, request.Context.User.Id));
        }
        catch
        {
            await socket.FollowupAsync(embed: _embedCollection.ErrorEmbed());
        }

        return Unit.Value;
    }
}
