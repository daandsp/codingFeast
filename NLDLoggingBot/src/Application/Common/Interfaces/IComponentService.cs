using Discord;
using Discord.Interactions;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IComponentService
{
    public Task<SelectMenuBuilder> CreateDisplayLogsSelectMenuAsync(int departmentId, int entryId, int skip, CancellationToken cancellationToken);
    public Task<SelectMenuBuilder> CreateDisplayLogsSelectMenuAsync(int departmentId, User user, int skip, CancellationToken cancellationToken);
    public SelectMenuBuilder CreateDisplayLogsSelectMenuAsync(List<LoggingEntry> loggingEntries, int skip);
    public Task<SelectMenuBuilder> CreateDisplayDepartmentLogsSelectMenuAsync(SocketInteractionContext context, int departmentId, int skip, CancellationToken cancellationToken);
    public SelectMenuBuilder CreateDisplayDepartmentLogsSelectMenuAsync(SocketInteractionContext context, List<User> users, int skip);
    public ButtonBuilder CreateDeleteLogButton(int entryId);
    public ButtonBuilder CreateShowUserLogsButton(ulong discordUserId);
    public List<ButtonBuilder> CreateUpdateSelectMenuRangeButtons(int count);
    public List<ButtonBuilder> CreateUpdateSelectMenuRangeButtons(int count, ulong userDiscordId);
}
