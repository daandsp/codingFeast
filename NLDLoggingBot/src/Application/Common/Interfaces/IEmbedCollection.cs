using Application.Common.Models.ApiModels;
using Discord;
using Discord.WebSocket;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IEmbedCollection
{
    public Embed NotFoundEmbed();
    public Embed ErrorEmbed();
    public Embed SuccessEmbed();
    public Embed DeletedLog();
    public Embed DeletedLogs(ulong guildUserId, int count);
    public Embed NoLogsFound(ulong guildUserId);
    public Embed NoUserFound(ulong guildUserId);
    public Embed RecentlyVerified();
    public Embed FailedToUpdateUser();
    public Embed UpdatedUser();
    public Embed NoDepartmentFound();
    public Embed NoDepartmentLogsFound(string departmentName);
    public Embed DeletedDepartmentLogs(string departmentName);
    public Embed NoBloxLinkResult();
    public Embed NoRobloxUserResult();
    public Embed LoggingEntryAdded(RobloxUserAndImage robloxUser, LoggingEntry loggingEntry, ulong guildUserId);
    public Embed DepartmentDiscordAdded(DepartmentGuild departmentDiscord);
    public Embed SetLogsChannel(SocketTextChannel? channel);
    public Embed SetAutomaticLogs(bool automaticLogs);
    public Embed DepartmentDiscordAlreadyExists();
    public Embed DepartmentDiscordNotChanged();
    public Embed DepartmentDiscordRemoved();
    public Embed PrimaryDepartmentDiscordAlreadyExists();
    public Embed NoPrimaryDiscordConfigured();
    public Embed NotPrimaryDiscord();
    public Embed GetDisplayLogsTotalEmbed(RobloxUserAndImage robloxUser, List<LoggingEntry> loggingEntries);
    public Embed GetDisplayDepartmentLogsTotalEmbed(Department department, List<LoggingEntry> loggingEntries);
    public Embed GetDisplayLogEmbed(RobloxUserAndImage robloxUser, LoggingEntry entry);
}
