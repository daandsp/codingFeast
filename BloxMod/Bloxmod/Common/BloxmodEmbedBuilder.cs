namespace Bloxmod.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Discord;

    /// <summary>
    /// A custom embed builder with a theme.
    /// </summary>
    internal class BloxmodEmbedBuilder : EmbedBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BloxmodEmbedBuilder"/> class.
        /// </summary>
        public BloxmodEmbedBuilder()
        {
            var bloxmodFooter = new EmbedFooterBuilder()
                .WithText("Bloxmod")
                .WithIconUrl("https://media.discordapp.net/attachments/426053020158263336/957661593934643220/Logo4.png");

            WithFooter(bloxmodFooter);
            WithColor(new Color(227, 39, 38));
            WithCurrentTimestamp();
        }
    }
}
