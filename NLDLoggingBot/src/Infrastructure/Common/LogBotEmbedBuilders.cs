using Discord;

namespace Infrastructure.Common;

public class LogBotEmbedBuilder : EmbedBuilder
{
    public LogBotEmbedBuilder()
    {
        var logBotFooter = new EmbedFooterBuilder()
            .WithText("Patrol Log Bot")
            .WithIconUrl("https://media.discordapp.net/attachments/828906479665807411/1022973186272407592/LogBotProfile.png");

        WithFooter(logBotFooter);
        WithColor(new Color(14, 60, 108));
        WithCurrentTimestamp();
    }
}
