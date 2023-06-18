using Bloxmod.ApiLibrary.Interfaces.Roblox;
using Bloxmod.ApiLibrary.Interfaces.Trello;
using Bloxmod.ApiLibrary.Services.Roblox;
using Bloxmod.ApiLibrary.Services.Trello;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bloxmod.ApiLibrary
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBloxmodApiServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScopedServices(configuration);

            return services;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IRobloxUserService, RobloxUserService>();
            services.AddScoped<ITrelloBoardService, TrelloBoardService>();
            services.AddScoped<ITrelloListService, TrelloListService>();
            services.AddScoped<ITrelloCardService, TrelloCardService>();

            return services;
        }
    }
}
