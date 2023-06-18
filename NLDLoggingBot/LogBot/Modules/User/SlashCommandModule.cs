using Application.Discord.Actions.Users.Commands.VerifyRobloxId;
using Discord.Interactions;
using MediatR;

namespace LogBot.Modules.User;

public class SlashCommandModule : LogBotModuleBase
{
    public SlashCommandModule(IMediator mediator)
        : base(mediator)
    { }

    [SlashCommand("verify", "Updates your robloxId connected to your discord account using bloxlink.")]
    public async Task VerifyRobloxId()
    {
        await PublishNotificationAsync<VerifyUserCmdNotification>(new(Context));
    }
}
