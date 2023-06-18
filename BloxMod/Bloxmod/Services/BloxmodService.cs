namespace Bloxmod.Services
{
    using Bloxmod.Data;
    using Discord.Addons.Hosting;
    using Discord.WebSocket;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A Custom implementation of <see cref="DiscordClientService"/> for Bloxmod.
    /// </summary>
    public abstract class BloxmodService : DiscordClientService
    {
        public readonly DiscordSocketClient Client;
        public readonly ILogger<DiscordClientService> Logger;
        public readonly IConfiguration Configuration;
        public readonly DataAccessLayer DataAccessLayer;

        public BloxmodService(DiscordSocketClient client, ILogger<DiscordClientService> logger, IConfiguration configuration, DataAccessLayer dataAccessLayer)
            : base(client, logger)
        {
            Client = client;
            Logger = logger;
            Configuration = configuration;
            DataAccessLayer = dataAccessLayer;
        }
    }
}
