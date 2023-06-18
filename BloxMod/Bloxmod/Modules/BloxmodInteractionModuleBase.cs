namespace Bloxmod.Modules
{
    using Bloxmod.ApiLibrary.Models;
    using Bloxmod.Common;
    using Bloxmod.Data;
    using Discord;
    using Discord.Interactions;

    public abstract class BloxmodInteractionModuleBase : InteractionModuleBase<SocketInteractionContext>
    {
        /// <summary>
        /// The <see cref="DataAccessLayer"/> of Bloxmod.
        /// </summary>
        public readonly DataAccessLayer DataAccessLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BloxmodInteractionModuleBase"/> class.
        /// </summary>
        /// <param name="dataAccessLayer">The <see cref="DataAccessLayer"/> to inject.</param>
        public BloxmodInteractionModuleBase(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        public Embed BuildEmbed(string title, string description)
        {
            var embed = new BloxmodEmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .Build();

            return embed;
        }

        public Embed BuildRobloxEmbed(
            string description,
            RobloxUserInformation robloxUser,
            RobloxUserThumbnail userThumbnail)
        {
            var embedAuthor = new EmbedAuthorBuilder()
                .WithName($"{robloxUser.name}")
                .WithIconUrl($"{userThumbnail.data[0].imageUrl}")
                .WithUrl($"https://www.roblox.com/users/{robloxUser.id}/profile");

            var embed = new BloxmodEmbedBuilder()
                .WithAuthor(embedAuthor)
                .WithDescription(description)
                .Build();

            return embed;
        }

        public Embed SendRobloxBanEmbedAsync(
            string reason,
            DateTime banDateTime,
            DateTime unbanDateTime,
            RobloxUserInformation robloxUser,
            RobloxUserThumbnail userThumbnail)
        {
            var embedAuthor = new EmbedAuthorBuilder()
                .WithName($"{robloxUser.name}")
                .WithIconUrl($"{userThumbnail.data[0].imageUrl}")
                .WithUrl($"https://www.roblox.com/users/{robloxUser.id}/profile");

            var embed = new BloxmodEmbedBuilder()
                .WithAuthor(embedAuthor)
                .AddField("Username:", robloxUser.name, false)
                .AddField("Ban reason:", reason, false)
                .AddField("Ban date:", $"{banDateTime.ToShortDateString()}, {banDateTime.ToShortTimeString()} CEST", false)
                .AddField("Unban date", $"{unbanDateTime.ToShortDateString()}, {unbanDateTime.ToShortTimeString()} CEST", false)
                .Build();

            return embed;
        }

        public async Task<Embed> SendRobloxUserInfoEmbedAsync(
            RobloxUserInformation robloxUser,
            RobloxUserThumbnail userThumbnail)
        {
            var embedAuthor = new EmbedAuthorBuilder()
                .WithName($"{robloxUser.name}")
                .WithIconUrl($"{userThumbnail.data[0].imageUrl}")
                .WithUrl($"https://www.roblox.com/users/{robloxUser.id}/profile");

            var embed = new BloxmodEmbedBuilder()
                .WithAuthor(embedAuthor)
                .WithThumbnailUrl($"{userThumbnail.data[0].imageUrl}")
                .AddField("Username:", robloxUser.name, false)
                .AddField("Created on:", robloxUser.created, false)

                // .AddField("Description:", robloxUserDetails.Description ?? "Empty", false)
                .AddField("UserID:", robloxUser.id, false)
                .Build();

            return embed;
        }
    }
}
