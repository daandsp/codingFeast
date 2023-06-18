using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using Domain.Entities;
using MediatR;

namespace Application.Actions.Discord.LogEntries.Commands;

public record DeleteDepartmentLoggingEntriesCommand : IRequest<Unit>
{
    public SocketInteractionContext Context { get; set; }
}

public class DeleteDepartmentLoggingEntriesCommandHandler : MediatRDiscordActionsBase, IRequestHandler<DeleteDepartmentLoggingEntriesCommand, Unit>
{
    public DeleteDepartmentLoggingEntriesCommandHandler(IDepartmentService departmentService,
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

    public async Task<Unit> Handle(DeleteDepartmentLoggingEntriesCommand request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;

        await socket.DeferAsync();
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

            var loggingEntries =
                await _entriesService.GetAllForDepartmentAsync(department.Id, cancellationToken);

            await _entriesService.DeleteListAsync(loggingEntries, cancellationToken);

            await socket.FollowupAsync(embed: _embedCollection.DeletedDepartmentLogs(department.Name));

            try
            {
                foreach (var guildUser in users.Select(user => request.Context.Guild.GetUser(user.DiscordId.Value)).Where(guildUser => guildUser != null))
                {
                    try
                    {
                        await guildUser.SendMessageAsync(
                            $"Your logs were wiped in {department.Name} by <@{request.Context.User.Id}>.");
                    }
                    catch { }
                }
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
