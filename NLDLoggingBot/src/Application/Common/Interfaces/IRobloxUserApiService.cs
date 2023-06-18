using Application.Common.Models.ApiModels;

namespace Application.Common.Interfaces;

public interface IRobloxUserApiService
{
    public Task<RobloxUserAndImage> GetFullUserAsync(string nameOrId, CancellationToken cancellationToken);
    public Task<BasicRobloxUser> GetBasicUserAsync(string nameOrId, CancellationToken cancellationToken);
    public Task<ImageInformation> GetUserImageByIdAsync(ulong Id, CancellationToken cancellationToken);
}