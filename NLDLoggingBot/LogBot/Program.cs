using Application;
using Discord;
using Discord.Addons.Hosting;
using Discord.Interactions;
using Discord.WebSocket;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogBot;

internal class Program
{
    private static async Task Main()
    {
        var builder = new HostBuilder()
            .ConfigureAppConfiguration(options =>
            {
                var dir = Directory.GetCurrentDirectory();

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(dir)
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();

                options.AddConfiguration(configuration);
            })
            .ConfigureLogging(options =>
            {
                options.AddConsole();
                options.SetMinimumLevel(LogLevel.Debug);
            })
            .ConfigureDiscordHost((context, config) =>
            {
                config.SocketConfig = new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Debug,
                    AlwaysDownloadUsers = true,
                    MessageCacheSize = 200,
                    GatewayIntents = GatewayIntents.All,
                };

                config.Token = context.Configuration.GetValue<string>("ApplicationSettings:DiscordBotToken");
            })
            .UseInteractionService((context, config) =>
            {
                config.LogLevel = LogSeverity.Debug;
                config.DefaultRunMode = RunMode.Async;
                config.UseCompiledLambda = true;
            })
            .ConfigureServices((context, services) =>
            {
                services.AddApplicationServices();
                services.AddLogBotServices(context.Configuration);
                services.AddInfrastructureServices(context.Configuration);
            })
            .UseConsoleLifetime();

        var host = builder.Build();
        using (var scope = host.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
            await initializer.InitialiseAsync();
            await initializer.SeedAsync();
        }

        using (host)
        {
            await host.RunAsync();
        }
    }
}
