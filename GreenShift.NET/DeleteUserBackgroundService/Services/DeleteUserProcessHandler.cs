using DeleteUserBackgroundService.Services.Interfaces;

namespace DeleteUserBackgroundService.Services;

internal class DeleteUserProcessHandler : IDeleteUserProcessHandler
{
    private readonly IApplicationUserService _applicationUserService;

    private readonly PeriodicTimer _timer = new(TimeSpan.FromMinutes(2));

    public DeleteUserProcessHandler(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService;
    }

    public async Task StartProcessAsync(CancellationToken cancellation)
    {
        while (await _timer.WaitForNextTickAsync(cancellation)
               && !cancellation.IsCancellationRequested)
        {
            var userIds = await _applicationUserService.GetInactiveUsersAsync(cancellation);

            var deletionTasks = userIds
                .Select(userId => _applicationUserService.DeleteSingleUserAsync(userId, cancellation))
                .ToList();

            await Task.WhenAll(deletionTasks);
        }
    }
}
