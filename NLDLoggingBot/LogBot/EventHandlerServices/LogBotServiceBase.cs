using Discord.Addons.Hosting;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LogBot.EventHandlerServices;

public abstract class LogBotServiceBase : DiscordClientService
{
    public new readonly DiscordSocketClient Client;
    public new readonly ILogger<DiscordClientService> Logger;
    public readonly IConfiguration Configuration;

    protected LogBotServiceBase(DiscordSocketClient client,
        ILogger<DiscordClientService> logger,
        IConfiguration configuration)
        : base(client, logger)
    {
        Client = client;
        Logger = logger;
        Configuration = configuration;
    }
}
