using LogBot.EventHandlerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogBot;

public static class ConfigureServices
{
    public static IServiceCollection AddLogBotServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEventHandlerServices();

        return services;
    }

    public static IServiceCollection AddEventHandlerServices(this IServiceCollection services)
    {
        services.AddHostedService<ClientReadyEventHandlerService>();

        return services;
    }
}
