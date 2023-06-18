using Application.Common.Models.ApiModels;

namespace Application.Common.Interfaces;

public interface IBloxLinkApiService
{
    public Task<BloxLinkRobloxUser?> GetRobloxIdByDiscordIdAsync(ulong discordId, CancellationToken cancellationToken);
}