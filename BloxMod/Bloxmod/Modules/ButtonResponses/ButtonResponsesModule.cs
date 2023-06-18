namespace Bloxmod.Modules.ButtonResponses
{
    using System.Threading.Tasks;
    using Bloxmod.Data;
    using Bloxmod.Models.Modals;
    using Discord.Interactions;

    public class ButtonResponsesModule : BloxmodInteractionModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonResponsesModule"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to be used.</param>
        /// <param name="dataAccessLayer">The <see cref="DataAccessLayer"/> to be used.</param>
        public ButtonResponsesModule(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        [ComponentInteraction("custom-id")]
        public async Task ButtonAsync()
        {
            await RespondAsync($"{Context.User.Mention} has clicked the button!");
        }

        [ComponentInteraction("trello_setupModal")]
        public async Task ModalAsync()
            => await Context.Interaction.RespondWithModalAsync<SetupTrelloModal>("submit_trello_setup");

        [ComponentInteraction("delete_reply")]
        public async Task DeleteReplyAsync()
        {
            await Context.Interaction.DeleteOriginalResponseAsync();
        }
    }
}
