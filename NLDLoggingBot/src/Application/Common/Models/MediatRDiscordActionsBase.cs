using Application.Common.Interfaces;
using Discord.Interactions;
using Domain.Entities;

namespace Application.Common.Models;

public class MediatRDiscordActionsBase
{
    protected readonly IDepartmentService _departmentService;
    protected readonly IDepartmentGuildService _departmentDiscordService;
    protected readonly IUserService _userService;
    protected readonly ILoggingEntriesService _entriesService;
    protected readonly IEmbedCollection _embedCollection;
    protected readonly IBloxLinkApiService _bloxLinkService;
    protected readonly IRobloxUserApiService _robloxUserService;
    protected readonly IComponentService _componentService;

    public MediatRDiscordActionsBase(IDepartmentService departmentService, 
        IDepartmentGuildService departmentDiscordService,
        IUserService userService, 
        ILoggingEntriesService entriesService, 
        IEmbedCollection embedCollection,
        IBloxLinkApiService bloxLinkApiService,
        IRobloxUserApiService robloxUserApiService,
        IComponentService componentService)
    {
        _departmentService = departmentService;
        _departmentDiscordService = departmentDiscordService;
        _userService = userService;
        _entriesService = entriesService;
        _embedCollection = embedCollection;
        _bloxLinkService = bloxLinkApiService;
        _robloxUserService = robloxUserApiService;
        _componentService = componentService;
    }

    protected async Task<(User User, bool FoundUser)> GetUserAsync(SocketInteractionContext context, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByDiscordIdAsync(context.User.Id, cancellationToken);

        if (user != null)
        {
            return (user, true);
        }

        var bloxLinkUser = await _bloxLinkService.GetRobloxIdByDiscordIdAsync(context.User.Id, cancellationToken);

        if (bloxLinkUser == null)
        {
            await context.Interaction.FollowupAsync(embed: _embedCollection.NoBloxLinkResult());
            return (null!, false);
        }

        user = await _userService.GetAsync(context.User.Id, Convert.ToUInt64(bloxLinkUser.robloxId), cancellationToken);

        return (user, true);
    }

    protected async Task<(Department Department, bool FoundDepartment)> GetDepartmentAsync(SocketInteractionContext context,
        CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetByChannelIdAsync(context.Channel.Id, cancellationToken);

        if (department != null)
        {
            return (department, true);
        }

        department = await _departmentService.GetByGuildIdAsync(context.Guild.Id, cancellationToken);

        if (department == null)
        {
            await context.Interaction.FollowupAsync(embed: _embedCollection.NoDepartmentFound());
        }

        return department == null ? (null!, false) : (department, true);
    }
}
