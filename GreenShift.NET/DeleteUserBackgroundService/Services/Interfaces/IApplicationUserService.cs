namespace DeleteUserBackgroundService.Services.Interfaces;

internal interface IApplicationUserService
{
    Task<List<string>> GetInactiveUsersAsync(CancellationToken cancellation);
    Task DeleteSingleUserAsync(string userId, CancellationToken cancellation);
}
