using Application.Common.Interfaces;
using Discord;
using Discord.Interactions;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Components;

public class ComponentService : IComponentService
{
    private readonly IUserService _userService;
    private readonly ILoggingEntriesService _loggingEntriesService;

    public ComponentService(IUserService userService, ILoggingEntriesService loggingEntriesService)
    {
        _userService = userService;
        _loggingEntriesService = loggingEntriesService;
    }

    public async Task<SelectMenuBuilder> CreateDisplayLogsSelectMenuAsync(int departmentId, int entryId, int skip, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByLoggingEntryIdAsync(entryId, cancellationToken);
        return await CreateDisplayLogsSelectMenuAsync(departmentId, user, skip, cancellationToken);
    }

    public async Task<SelectMenuBuilder> CreateDisplayLogsSelectMenuAsync(int departmentId, User user, int skip, CancellationToken cancellationToken)
    {
        var loggingEntries =
            await _loggingEntriesService.GetAllForUserAsync(departmentId, user.Id, cancellationToken);
        return CreateDisplayLogsSelectMenuAsync(loggingEntries, skip);
    }

    public SelectMenuBuilder CreateDisplayLogsSelectMenuAsync(List<LoggingEntry> loggingEntries, int skip)
    {
        var menuBuilder = new SelectMenuBuilder()
            .WithPlaceholder($"Select patrol  {skip + 1} - {skip + 25}")
            .WithCustomId("display-user-log");

        var i = skip + 1;
        foreach (var entry in loggingEntries.Skip(skip).Take(25))
        {
            menuBuilder.AddOption($"{i} - {entry.DateCreated.ToShortTimeString()}", $"{entry.Id}", $"{entry.DateCreated.ToLongDateString()}");
            i++;
        }

        return menuBuilder;
    }

    public async Task<SelectMenuBuilder> CreateDisplayDepartmentLogsSelectMenuAsync(SocketInteractionContext context, int departmentId, int skip, CancellationToken cancellationToken)
    {
        var users = await _userService.GetUsersWithDepartmentLogsAsync(departmentId, cancellationToken);
        return CreateDisplayDepartmentLogsSelectMenuAsync(context, users, skip);
    }

    public SelectMenuBuilder CreateDisplayDepartmentLogsSelectMenuAsync(SocketInteractionContext context, List<User> users, int skip)
    {
        var menuBuilder = new SelectMenuBuilder()
            .WithPlaceholder($"Select user {skip + 1} - {skip + 25}")
            .WithCustomId("display-user-logs-total");

        var i = skip + 1;
        var guildUsers = users.Select(user => context.Guild.GetUser(user.DiscordId.Value)).Where(guildUser => guildUser != null);
        foreach (var guildUser in guildUsers.Skip(skip).Take(25))
        {
            menuBuilder.AddOption($"{i} - {guildUser.DisplayName}", $"{guildUser.Id}", $"{guildUser.Username}");
            i++;
        }

        return menuBuilder;
    }

    public ButtonBuilder CreateDeleteLogButton(int entryId)
    {
        return new ButtonBuilder()
            .WithCustomId($"delete-user-log:{entryId}")
            .WithLabel("Delete")
            .WithStyle(ButtonStyle.Danger);
    }

    public ButtonBuilder CreateShowUserLogsButton(ulong discordUserId)
    {
        return new ButtonBuilder()
            .WithCustomId($"display-user-logs:{discordUserId}")
            .WithLabel("Display Logs")
            .WithStyle(ButtonStyle.Primary);
    }

    public List<ButtonBuilder> CreateUpdateSelectMenuRangeButtons(int count)
    {
        return CreateUpdateSelectMenuRangeButtons(count, RangeButtonsType.Users, 0);
    }
    public List<ButtonBuilder> CreateUpdateSelectMenuRangeButtons(int count, ulong userDiscordId)
    {
        return CreateUpdateSelectMenuRangeButtons(count, RangeButtonsType.Logs, userDiscordId);
    }
    private List<ButtonBuilder> CreateUpdateSelectMenuRangeButtons(int count, RangeButtonsType type, ulong userDiscordId)
    {
        var customId = "update-users-select-range";

        if (type == RangeButtonsType.Logs)
        {
            customId = "update-logs-select-range";
        }

        int numBoxes = Math.DivRem(count, 25, out int remainder);
        var buttonList = new List<ButtonBuilder>();

        if (numBoxes < 1 || (numBoxes == 1 && remainder == 0))
        {
            return buttonList;
        }

        for (int i = 0; i <= numBoxes - 1; i++)
        {
            var skip = i * 25 + 1;
            var take = (i + 1) * 25;
            buttonList.Add(CreateButton(customId, skip, take, userDiscordId));
        }

        if (remainder == 0)
        {
            return buttonList;
        }

        {
            var skip = buttonList.Count * 25 + 1;
            var take = (buttonList.Count + 1) * 25;
            buttonList.Add(CreateButton(customId, skip, take, userDiscordId));
        }

        return buttonList;
    }

    private ButtonBuilder CreateButton(string customId, int skip, int take, ulong? userDiscordId)
    {
        var fullCustomId = userDiscordId != null && userDiscordId != 0
            ? $"{customId}:{skip - 1}:{userDiscordId}"
            : $"{customId}:{skip - 1}";

        Console.WriteLine(fullCustomId);

        return new ButtonBuilder()
            .WithCustomId($"{fullCustomId}")
            .WithLabel($"{skip} - {take}")
            .WithStyle(ButtonStyle.Primary);
    }
}
