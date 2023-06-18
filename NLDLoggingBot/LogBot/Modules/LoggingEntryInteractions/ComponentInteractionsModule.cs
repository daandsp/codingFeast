using Application.Actions.Discord.LogEntries.Interactions;
using Application.Common.Interfaces;
using Discord.Interactions;
using LogBot.Common.Attributes;
using MediatR;

namespace LogBot.Modules.LoggingEntryInteractions;

public class ComponentInteractionsModule : LogBotModuleBase
{
    public ComponentInteractionsModule(IMediator mediator)
        : base(mediator)
    { }

    [ComponentInteraction("display-user-log")]
    public async Task SelectSpecificUserLogs(string id, string[] x)
    {
        await MediatorActionAsync<DisplayUserLogEntryInteraction>(new()
        {
            EntryId = id,
            Context = Context
        });
    }

    [ComponentInteraction("display-user-logs-total")]
    public async Task SelectSpecificUserlogsTotal(string id, string[] x)
    {
        await MediatorActionAsync<DisplayDepartmentUserLoggingEntriesTotalByDiscordIdInteraction>(new()
        {
            DiscordUserId = id,
            Context = Context
        });
    }

    [ComponentInteraction("display-user-logs:*")]
    public async Task DisplayUserLogs(ulong discordUserId)
    {
        await MediatorActionAsync<DisplayUserLoggingEntriesInteraction>(new()
        {
            DiscordUserId = discordUserId,
            Context =  Context
        });
    }

    [RequireLoggingBotAccess]
    [ComponentInteraction("delete-user-log:*")]
    public async Task DeleteSpecificUserLog(int id)
    {
        await MediatorActionAsync<DeleteUserLogEntryInteraction>(new()
        {
            EntryId = id, 
            Context = Context
        });
    }

    [ComponentInteraction("update-logs-select-range:*:*")]
    public async Task UpdateLogsSelectRange(int skip, ulong discordId)
    {

        await MediatorActionAsync<UpdateLogsSelectMenuRangeInteraction>(new()
        {
            Skip = skip,
            DiscordUserId = discordId,
            Context = Context
        });
    }

    [ComponentInteraction("update-users-select-range:*")]
    public async Task UpdateUsersSelectRange(int skip)
    {

        await MediatorActionAsync<UpdateUsersSelectMenuRangeInteraction>(new()
        {
            Skip = skip,
            Context = Context
        });
    }
}
