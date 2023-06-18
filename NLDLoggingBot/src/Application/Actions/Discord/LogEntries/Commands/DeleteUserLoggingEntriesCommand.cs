using System.Reflection.Metadata.Ecma335;
using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Domain.Entities;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Commands;

public record DeleteUserLoggingEntriesCommand : IRequest<Unit>
{
    public IUser User { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class DeleteUserLoggingEntriesCommandHandler : MediatRDiscordActionsBase, IRequestHandler<DeleteUserLoggingEntriesCommand, Unit>
{
    public DeleteUserLoggingEntriesCommandHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(DeleteUserLoggingEntriesCommand request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;

        await socket.DeferAsync();
        try
        {
            (var user, bool foundUser) = await GetUserAsync(request.Context, cancellationToken);
            (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

            if (!foundUser || !foundDept)
            {
                return Unit.Value;
            }

            var loggingEntries =
                await _entriesService.GetAllForUserAsync(department.Id, user.Id, cancellationToken);

            if (!loggingEntries.Any())
            {
                await socket.FollowupAsync(embed: _embedCollection.NoLogsFound(request.User.Id));
                return Unit.Value;
            }

            await _entriesService.DeleteListAsync(loggingEntries, cancellationToken);

            await socket.FollowupAsync(embed: _embedCollection.DeletedLogs(request.User.Id, loggingEntries.Count));

            try
            {
                await request.User.SendMessageAsync(
                        $"Your logs were wiped in {department.Name} by <@{request.Context.User.Id}>.");
            }
            catch { }
        }
        catch
        {
            await socket.RespondAsync(embed: _embedCollection.ErrorEmbed());
        }

        return Unit.Value;
    }
}
