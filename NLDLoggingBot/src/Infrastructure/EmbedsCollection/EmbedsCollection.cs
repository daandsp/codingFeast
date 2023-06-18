using Application.Common.ExtensionMethods;
using Application.Common.Interfaces;
using Application.Common.Models.ApiModels;
using Discord;
using Discord.WebSocket;
using Domain.Entities;
using Infrastructure.Common;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EmbedsCollection;

public class EmbedsCollection : IEmbedCollection
{
    private readonly IConfiguration _config;

    public EmbedsCollection(IConfiguration config)
    {
        _config = config;
    }

    public Embed NotFoundEmbed()
    {
        return NotFoundEmbed("Something went wrong with your request.");
    }

    public Embed ErrorEmbed()
    {
        return ErrorEmbed("Something went wrong with your request.");
    }

    public Embed SuccessEmbed()
    {
        return SuccessEmbed("Done.");
    }

    public Embed DeletedLog()
    {
        return LogsEmbed("Deleted log.");
    }

    public Embed DeletedLogs(ulong guildUserId, int count)
    {
        return SuccessEmbed($"Deleted {count} log(s) for <@{guildUserId}>.");
    }

    public Embed NoLogsFound(ulong guildUserId)
    {
        return NotFoundEmbed($"There are no logs for <@{guildUserId}>.");
    }

    public Embed NoUserFound(ulong guildUserId)
    {
        return WarningEmbed($"It seems like <@{guildUserId}> has never used my services before.");
    }

    public Embed RecentlyVerified()
    {
        return WarningEmbed("You already ran this command today.");
    }

    public Embed FailedToUpdateUser()
    {
        return NotFoundEmbed("I was unable to update your data, please try again.");
    }

    public Embed UpdatedUser()
    {
        return SuccessEmbed("Successfully updated your data.");
    }

    public Embed NoDepartmentFound()
    {
        return ConfigurationEmbed($"It seems like this server has not yet been linked to a department, please contact <@{_config.GetValue<ulong>("ApplicationSettings:BotOwnerId")}>.");
    }

    public Embed NoDepartmentLogsFound(string departmentName)
    {
        return NotFoundEmbed($"No logs were found for {departmentName}.");
    }

    public Embed DeletedDepartmentLogs(string departmentName)
    {
        return DepartmentEmbed($"Deleted all logs for {departmentName}");
    }

    public Embed NoBloxLinkResult()
    {
        return NotFoundEmbed("Bloxlink was unable to provide me with your roblox account ID.");
    }

    public Embed NoRobloxUserResult()
    {
        return NotFoundEmbed("Roblox was unable to provide me with the roblox ID linked to your discord account.");
    }

    public Embed LoggingEntryAdded(RobloxUserAndImage robloxUser, LoggingEntry loggingEntry, ulong guildUserId)
    {
        var embedAuthor = new EmbedAuthorBuilder()
            .WithName($"Patrol logged for {robloxUser.RobloxUser.Name}")
            .WithIconUrl($"{robloxUser.Image?.ImageUrl}")
            .WithUrl($"https://www.roblox.com/users/{robloxUser.RobloxUser?.Id}/profile");

        var embed = new LogBotEmbedBuilder()
            .WithAuthor(embedAuthor)
            .AddField("Hours logged", $"{loggingEntry.GetIntervalDuration().Hours}", true)
            .AddField("Minutes logged", $"{loggingEntry.GetIntervalDuration().Minutes}", true)
            .Build();

        return embed;
    }

    public Embed DepartmentDiscordAdded(DepartmentGuild departmentDiscord)
    {
        return ConfigurationEmbed($"This discord is now linked to {departmentDiscord.Department.Name}");
    }

    public Embed SetLogsChannel(SocketTextChannel? channel)
    {
        if (channel == null)
        {
            return ConfigurationEmbed($"Removed the logs channel.");
        }

        return ConfigurationEmbed($"Set the logs channel to: <#{channel.Id}>.");
    }

    public Embed SetAutomaticLogs(bool automaticLogs)
    {
        if (automaticLogs)
        {
            return ConfigurationEmbed("Enabled automatic logs for this department.");
        }

        return ConfigurationEmbed("Disabled automatic logs for this department.");
    }

    public Embed DepartmentDiscordAlreadyExists()
    {
        return WarningEmbed("This server is already linked to a department.");
    }

    public Embed DepartmentDiscordNotChanged()
    {
        return WarningEmbed("This server is already linked to this department.");
    }

    public Embed DepartmentDiscordRemoved()
    {
        return ConfigurationEmbed("Successfully removed the department connection.");
    }

    public Embed PrimaryDepartmentDiscordAlreadyExists()
    {
        return WarningEmbed("This department already has a primary discord set-up.");
    }

    public Embed NoPrimaryDiscordConfigured()
    {
        return WarningEmbed("There is no primary discord configured for this department.");
    }

    public Embed NotPrimaryDiscord()
    {
        return WarningEmbed("This command can only be run in the primary discord for this department.");
    }

    public Embed GetDisplayLogsTotalEmbed(RobloxUserAndImage robloxUser, List<LoggingEntry> loggingEntries)
    {
        var firstLog = loggingEntries.OrderBy(entry => entry.DateCreated).First();
        var timeSpan = loggingEntries.GetLoggingTotal();

        var embedAuthor = new EmbedAuthorBuilder()
            .WithName($"Displaying {loggingEntries.Count} patrol(s) for {robloxUser.RobloxUser?.Name}")
            .WithIconUrl($"{robloxUser.Image?.ImageUrl}")
            .WithUrl($"https://www.roblox.com/users/{robloxUser.RobloxUser?.Id}/profile");

        var embed = new LogBotEmbedBuilder()
            .WithAuthor(embedAuthor)
            .AddField("Logged since", $"{firstLog.DateCreated.ToUniversalTime().ToLongDateString()} at {firstLog.DateCreated.ToUniversalTime().ToShortTimeString()} UTC");

        if (timeSpan.Days > 0)
        {
            embed.AddField("Total days", $"{timeSpan.Days}", true);
        }

        embed.AddField("Total hours", $"{timeSpan.Hours}", true);
        embed.AddField("Total minutes", $"{timeSpan.Minutes}", true);

        return embed.Build();
    }

    public Embed GetDisplayDepartmentLogsTotalEmbed(Department department, List<LoggingEntry> loggingEntries)
    {
        var firstLog = loggingEntries.OrderBy(entry => entry.DateCreated).First();
        var timeSpan = loggingEntries.GetLoggingTotal();

        var embed = new LogBotEmbedBuilder()
            .WithTitle($"{department.Name}")
            .WithDescription($"Displaying {loggingEntries.Count} log(s)")
            .AddField("Logged since", $"{firstLog.DateCreated.ToUniversalTime().ToLongDateString()} at {firstLog.DateCreated.ToUniversalTime().ToShortTimeString()} UTC");

        if (timeSpan.Days > 0)
        {
            embed.AddField("Total days", $"{timeSpan.Days}", true);
        }

        embed.AddField("Total hours", $"{timeSpan.Hours}", true);
        embed.AddField("Total minutes", $"{timeSpan.Minutes}", true);

        return embed.Build();
    }

    public Embed GetDisplayLogEmbed(RobloxUserAndImage robloxUser, LoggingEntry entry)
    {
        var embedAuthor = new EmbedAuthorBuilder()
            .WithName($"Displaying patrol for {robloxUser.RobloxUser?.Name}")
            .WithIconUrl($"{robloxUser.Image?.ImageUrl}")
            .WithUrl($"https://www.roblox.com/users/{robloxUser.RobloxUser?.Id}/profile");

        var embed = new LogBotEmbedBuilder()
            .WithAuthor(embedAuthor)
            .AddField("Logged on", $"{entry.DateCreated.ToUniversalTime().ToLongDateString()} at {entry.DateCreated.ToUniversalTime().ToShortTimeString()} UTC")
            .AddField("Hours logged", $"{entry.GetIntervalDuration().Hours}", true)
            .AddField("Minutes logged", $"{entry.GetIntervalDuration().Minutes}", true)
            .Build();

        return embed;
    }

    private Embed NotFoundEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("Not Found")
            .WithDescription(description)
            .Build();
    }

    private Embed ErrorEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("Error")
            .WithDescription(description)
            .Build();
    }

    private Embed SuccessEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("Success")
            .WithDescription(description)
            .Build();
    }

    private Embed WarningEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("Warning")
            .WithDescription(description)
            .Build();
    }

    private Embed ConfigurationEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("Configuration")
            .WithDescription(description)
            .Build();
    }

    private Embed LogsEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("Logs")
            .WithDescription(description)
            .Build();
    }

    private Embed DepartmentEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("Department")
            .WithDescription(description)
            .Build();
    }

    private Embed UserEmbed(string description)
    {
        return new LogBotEmbedBuilder()
            .WithTitle("User")
            .WithDescription(description)
            .Build();
    }
}
