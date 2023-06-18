using DeleteUserBackgroundService;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.AddApplicationDbcontextServices(configuration);
        services.AddDeleteUserServices();
        services.AddScopedServices(configuration);
        services.AddIdentityServices(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
