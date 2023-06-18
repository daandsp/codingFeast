namespace Bloxmod.Modules
{
    using Bloxmod.Common;
    using Bloxmod.Data;
    using Discord.Commands;
    using Discord.Rest;

    /// <summary>
    /// A custom implementation of <see cref="ModuleBase"/> for Erik.
    /// </summary>
    public abstract class BloxmodModuleBase : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// The <see cref="DataAccessLayer"/> of Bloxmod.
        /// </summary>
        public readonly DataAccessLayer DataAccessLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BloxmodModuleBase"/> class.
        /// </summary>
        /// <param name="dataAccessLayer">The <see cref="DataAccessLayer"/> to inject.</param>
        public BloxmodModuleBase(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        /// <summary>
        /// Send an embed containing a title and description to a channel.
        /// </summary>
        /// <param name="title">The title of the embed.</param>
        /// <param name="description">The description of the embed.</param>
        /// <returns> A <see cref="RestUserMessage"/> containing the embed.</returns>
        public async Task<RestUserMessage> SendEmbedAsync(string title, string description)
        {
            var builder = new BloxmodEmbedBuilder()
                .WithTitle(title)
                .WithDescription(description);

            return await Context.Channel.SendMessageAsync(embed: builder.Build());
        }
    }
}
