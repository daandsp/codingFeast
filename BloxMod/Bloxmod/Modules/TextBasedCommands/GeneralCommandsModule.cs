namespace Bloxmod.Modules.TextBasedCommands
{
    using System.Threading.Tasks;
    using Bloxmod.Common;
    using Bloxmod.Data;
    using Bloxmod.Modules;
    using Bloxmod.TrelloLibrary;
    using Discord;
    using Discord.Commands;
    using Discord.Interactions;
    using Discord.WebSocket;
    using RequireOwnerAttribute = Discord.Commands.RequireOwnerAttribute;

    /// <summary>
    /// The general module containing commands.
    /// </summary>
    public class GeneralCommandsModule : BloxmodModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralCommandsModule"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to be used.</param>
        /// <param name="dataAccessLayer">The <see cref="DataAccessLayer"/> to be used.</param>
        public GeneralCommandsModule(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        /// <summary>
        /// A command that gives you some information about a user.
        /// </summary>
        /// <param name="socketGuildUser">An optional user to get the information from.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("Info")]
        public async Task InfoAsync(SocketGuildUser? socketGuildUser = null)
        {
            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }

            var embed1 = new BloxmodEmbedBuilder()
                .WithTitle($"{socketGuildUser.Username}#{socketGuildUser.DiscriminatorValue}")
                .WithThumbnailUrl(socketGuildUser.GetAvatarUrl() ?? socketGuildUser.GetDefaultAvatarUrl())
                .AddField("ID", socketGuildUser.Id, false)
                .AddField("Name", $"{socketGuildUser.Username}#{socketGuildUser.DiscriminatorValue}", false)
                .AddField("Created on", socketGuildUser.CreatedAt, false)
                .Build();

            await ReplyAsync(embed: embed1);
        }

        [Command("Download")]
        [RequireOwner]
        public async Task DownloadAsync()
        {
            await Context.Channel.TriggerTypingAsync();
            var guild = Context.Guild as SocketGuild;
            await guild.DownloadUsersAsync();
            await ReplyAsync("Finished Downloading");
        }

        [Command("owner")]
        [RequireOwner]
        public async Task ownerAsync()
        {
            var embed = new BloxmodEmbedBuilder()
                .WithTitle($"Hello {Context.User.Username}")
                .WithDescription("<@408323172035985426> is the creator of Bloxmod")
                .Build();

            await ReplyAsync(embed: embed);
        }
    }
}
