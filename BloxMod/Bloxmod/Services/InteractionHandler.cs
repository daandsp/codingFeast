namespace Bloxmod.Services
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using Bloxmod.Data;
    using Discord.Interactions;
    using Discord.WebSocket;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The class responsible for handling the interactions and various events.
    /// </summary>
    public class InteractionHandler : BloxmodService
    {
        private readonly IServiceProvider _provider;
        private readonly IConfiguration _config;
        private readonly InteractionService _interactionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionHandler"/> class.
        /// </summary>
        /// <param name="client">The <see cref="DiscordSocketClient"/> that should be injected.</param>
        /// <param name="logger">The <see cref="ILogger"/> that should be injected.</param>
        /// <param name="provider">The <see cref="IServiceProvider"/> that should be injected.</param>
        /// <param name="config">The <see cref="IConfiguration"/> that should be injected.</param>
        /// /// <param name="interactionService">The <see cref="InteractionService"/> that should be injected.</param>
        public InteractionHandler(DiscordSocketClient client, ILogger<CommandHandler> logger, IServiceProvider provider, IConfiguration configuration, InteractionService interactionService, DataAccessLayer dataAccessLayer)
            : base(client, logger, configuration, dataAccessLayer)
        {
            _provider = provider;
            _config = configuration;
            _interactionService = interactionService;
        }

        /// <inheritdoc/>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Client.Ready += Client_Ready;
            await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }

        private async Task Client_Ready()
        {
            await _interactionService.RegisterCommandsToGuildAsync(guildId: 931181175094001704, deleteMissing: true);

            Client.InteractionCreated += async interaction =>
            {
                var scope = _provider.CreateScope();
                var ctx = new SocketInteractionContext(Client, interaction);
                await _interactionService.ExecuteCommandAsync(ctx, scope.ServiceProvider);
            };
        }
    }
}
