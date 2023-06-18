namespace DeleteUserBackgroundService.Services.Interfaces;

internal interface IDeleteUserProcessHandler
{
    Task StartProcessAsync(CancellationToken cancellation);
}
