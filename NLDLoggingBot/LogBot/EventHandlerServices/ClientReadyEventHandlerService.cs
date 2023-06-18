using System.Reflection;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogBot.EventHandlerServices;

public class ClientReadyEventHandlerService : LogBotServiceBase
{
    private readonly IServiceProvider _provider;
    private readonly IConfiguration _config;
    private readonly InteractionService _interactionService;

    public ClientReadyEventHandlerService(DiscordSocketClient client,
        ILogger<ClientReadyEventHandlerService> logger,
        IServiceProvider provider,
        IConfiguration configuration,
        InteractionService interactionService)
        : base(client, logger, configuration)
    {
        _provider = provider;
        _config = configuration;
        _interactionService = interactionService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Client.Ready += Client_Ready;
        await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
    }

    private async Task Client_Ready()
    {
        //await _interactionService.RegisterCommandsGloballyAsync(true);
        await _interactionService.RegisterCommandsToGuildAsync(931181175094001704, true);

        Client.InteractionCreated += async interaction =>
        {
            var scope = _provider.CreateScope();
            var ctx = new SocketInteractionContext(Client, interaction);
            await _interactionService.ExecuteCommandAsync(ctx, scope.ServiceProvider);
        };

        Client.JoinedGuild += async socketGuild =>
        {
            var moderatorRoleName = _config.GetValue<string>("ApplicationSettings:ModeratorRoleName");

            if (socketGuild.Roles.Any(role => role.Name == moderatorRoleName))
            {
                return;
            }

            await socketGuild.CreateRoleAsync(moderatorRoleName);
        };
    }
}

