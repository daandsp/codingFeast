using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace LogBot.Common.Attributes;

public class RequireLoggingBotAccess : PreconditionAttribute
{
    private const string ModeratorRoleName = "LoggingBot Access";

    public RequireLoggingBotAccess() { }

    public override Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
    {
        if (context.User is not SocketGuildUser guildUser)
        {
            context.Interaction.RespondAsync("This command can only be used in a server.", ephemeral: true);
            return Task.FromResult(PreconditionResult.FromError("This command can only be used in a server."));
        }

        if (guildUser.Roles.Any(role => role.Name == ModeratorRoleName))
        {
            return Task.FromResult(PreconditionResult.FromSuccess());
        }
        else
        {
            context.Interaction.RespondAsync($"You do not have the required '{ModeratorRoleName}' role in order to interact with this action.", ephemeral: true);
            return Task.FromResult(PreconditionResult.FromError($"You do not have the required '{ModeratorRoleName}' role in order to interact with this action."));
        }
    }
}
