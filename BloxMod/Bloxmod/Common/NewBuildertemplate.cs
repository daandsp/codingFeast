using Discord;


namespace Bloxmod.Common
{
    internal class NewBuildertemplate : EmbedBuilder
    {
        public NewBuildertemplate()
        {
            var Footer = new EmbedFooterBuilder()
                .WithText("Bloxmod");
            WithFooter(Footer);
            var Author = new EmbedAuthorBuilder()
                .WithName("daandsp and DeEchteBelg");
            WithAuthor(Author);
            WithColor(new Color(227, 39, 38));
            WithCurrentTimestamp();
        }
    }
}
