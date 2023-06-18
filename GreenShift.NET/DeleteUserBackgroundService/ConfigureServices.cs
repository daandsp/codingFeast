using DeleteUserBackgroundService.Services;
using DeleteUserBackgroundService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DeleteUserBackgroundService;

public static class ConfigureServices
{
    internal static IServiceCollection AddDeleteUserServices(this IServiceCollection services)
    {
        services.AddScopedServices();

        return services;
    }

    internal static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationUserService, ApplicationUserService>();

        return services;
    }
}
