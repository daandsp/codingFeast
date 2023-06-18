using DeleteUserBackgroundService.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DeleteUserBackgroundService;

internal class Worker : BackgroundService
{
    private readonly IDeleteUserProcessHandler _processHandler;

    public Worker(IDeleteUserProcessHandler processHandler)
    {
        _processHandler = processHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellation)
    {
        await _processHandler.StartProcessAsync(cancellation);
    }
}
