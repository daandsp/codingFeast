namespace Bloxmod
{
    using Bloxmod.ApiLibrary;
    using Bloxmod.Data;
    using Bloxmod.Data.Context;
    using Bloxmod.Services;
    using Discord;
    using Discord.Addons.Hosting;
    using Discord.Interactions;
    using Discord.WebSocket;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The entry point of the bot.
    /// </summary>
    internal class Program
    {
        private static async Task Main()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(x =>
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .Build();

                    x.AddConfiguration(configuration);
                })
                .ConfigureLogging(x =>
                {
                    x.AddConsole();
                    x.SetMinimumLevel(LogLevel.Debug);
                })
                .ConfigureDiscordHost((context, config) =>
                {
                    config.SocketConfig = new DiscordSocketConfig
                    {
                        LogLevel = Discord.LogSeverity.Debug,
                        AlwaysDownloadUsers = true,
                        MessageCacheSize = 200,
                        GatewayIntents = GatewayIntents.All,
                    };

                    config.Token = context.Configuration.GetValue<string>("ApplicationSettings:DiscordBotToken");
                })
                .UseCommandService((context, config) =>
                {
                    config.CaseSensitiveCommands = false;
                    config.LogLevel = Discord.LogSeverity.Debug;
                    config.DefaultRunMode = Discord.Commands.RunMode.Async;
                })
                .UseInteractionService((context, config) =>
                {
                    config.LogLevel = LogSeverity.Debug;
                    config.DefaultRunMode = RunMode.Async;
                    config.UseCompiledLambda = true;
                })
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddHostedService<CommandHandler>()
                        .AddHostedService<InteractionHandler>()
                        .AddBloxmodDataServices(context.Configuration)
                        .AddBloxmodApiServices(context.Configuration)
                        .AddHttpClient();
                })
                .UseConsoleLifetime();

            var host = builder.Build();
            using (var scope = host.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<BloxmodDbContextInitializer>();
                await initializer.InitialiseAsync();
            }

            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}