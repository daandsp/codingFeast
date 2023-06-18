namespace Bloxmod.Modules.SlashCommands
{
    using System.Threading.Tasks;
    using Bloxmod.ApiLibrary.Interfaces.Roblox;
    using Bloxmod.Common;
    using Bloxmod.Data;
    using Discord;
    using Discord.Interactions;

    public class GeneralInteractionsModule : BloxmodInteractionModuleBase
    {
        private readonly IRobloxUserService _robloxUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralInteractionsModule"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to be used.</param>
        /// <param name="dataAccessLayer">The <see cref="DataAccessLayer"/> to be used.</param>
        public GeneralInteractionsModule(IRobloxUserService robloxUserService, DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
            _robloxUserService = robloxUserService;
        }

        [SlashCommand("roblox-user", "Get information about a roblox user")]
        public async Task RobloxUser([Summary(description: "The name or Id of the user")] string usernameUserid)
        {
            await DeferAsync();
            var robloxUser = await _robloxUserService.GetRobloxUserByNameOrIdAsync(usernameUserid);
            var userThumbnail = await _robloxUserService.GetRobloxUserThumbnailAsync(robloxUser.id);

            if (robloxUser == null)
            {
                await FollowupAsync(embed: BuildEmbed("Not Found", "The user was not found."));
                return;
            }

            await FollowupAsync(embed: await SendRobloxUserInfoEmbedAsync(robloxUser, userThumbnail));
        }

        [SlashCommand("game-ban", "Ban a player from your roblox game")]
        public async Task GameBanAsync(
            [Summary(description: "The name or Id of the user")] string usernameUserid,
            [Summary(description: "Ban length")] int banLength,
            [Summary(description: "Ban reason")] string reason)
        {
            await DeferAsync();
            var robloxUser = await _robloxUserService.GetRobloxUserByNameOrIdAsync(usernameUserid);
            var userThumbnail = await _robloxUserService.GetRobloxUserThumbnailAsync(robloxUser.id);

            var banDate = DateTime.Now;
            var unbanDate = banDate.AddDays(banLength);

            if (robloxUser == null)
            {
                await FollowupAsync(embed: BuildEmbed("Not Found", "The user was not found."));
                return;
            }

            //await TrelloLibrary.CreateBanCard(robloxUser.name, robloxUser.id);
            await FollowupAsync(embed: SendRobloxBanEmbedAsync(reason, banDate, unbanDate, robloxUser, userThumbnail));
        }

        [RequireUserPermission(GuildPermission.Administrator)]
        [SlashCommand("trello-setup", "Setup trello to start using Bloxmod's banning feature")]
        public async Task ButtonAsync()
        {
            var embed = new BloxmodEmbedBuilder()
                .WithTitle("Setup trello for Bloxmod")
                .AddField("Step 1", "Go to trello and copy the board ID of the board you want Bloxmod to use as banlist. \n\n **How to get a board Id:** \n Log into your trello account and go to the board you wish to use. Then copy your id which is highlighted in this example: ``trello.com/b/**123456ID**/dummyname``.")
                .AddField("Step 2", "Click the 'step 2' button and copy your key.")
                .AddField("Step 3", "Click the 'step 3' button and paste your key in the ``[PASTE_YOUR_KEY_HERE]`` section of the link.")
                .AddField("Step 4", "Allow Bloxmod access to your trello and copy the API token trello gives you. \n\n**REMINDER:** \n *Do **NOT** share the token you got in this step with anyone else, this will give them access to your account.*")
                .AddField("Step 5", "Click the 'Step 5' button and fill in the fields with the keys you just got.")
                .AddField("Step 6", "Start banning people left and right you don't like.")
                .Build();

            var builder = new ComponentBuilder()
                .WithButton("Step 2", null, ButtonStyle.Link, url: "https://trello.com/app-key")
                .WithButton("Step 3", null, ButtonStyle.Link, url: "https://trello.com/1/connect?name=Bloxmod_Dashboard&response_type=token&expires=never&scope=read,write&key=[PASTE_YOUR_KEY_HERE]")
                .WithButton("Step 5", "trello_setupModal")
                // .WithButton("Cancel", "delete_reply", ButtonStyle.Danger)
                .Build();

            await RespondAsync(components: builder, embed: embed, ephemeral: true);
        }
        [SlashCommand("test", "Let's start with something new")]
        public async Task TestAsync([Summary(description: "What have I done")]string action)
        {
            await DeferAsync();
            var embed = new NewBuildertemplate()
                .WithTitle("Goodmorning")
                .AddField("What have I done?", action)
                .Build();
            await FollowupAsync(embed: embed);
        }
    }
}
