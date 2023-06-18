namespace Bloxmod.Modules.ModalResponses
{
    using System.Threading.Tasks;
    using Bloxmod.Data;
    using Bloxmod.Models.Modals;
    using Discord;
    using Discord.Interactions;

    public class ModalResponsesModule : BloxmodInteractionModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModalResponsesModule"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to be used.</param>
        /// <param name="dataAccessLayer">The <see cref="DataAccessLayer"/> to be used.</param>
        public ModalResponsesModule(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        // Responds to the modal.
        //[ModalInteraction("submit_trello_setup")]
        //public async Task ModalResponce(SetupTrelloModal modal)
        //{

        //    private readonly IDbContextFactory<BloxmodDbContext> _contextFactory;

        //    public DataAccessLayer(IDbContextFactory<BloxmodDbContext> contextFactory)
        //    {
        //        _contextFactory = contextFactory;
        //    }

        //    if (DataAccessLayer == null)
        //    {
        //        await ReplyAsync("An error occured, please try again later.");
        //        return;
        //    }

        //    await DataAccessLayer.SetTrelloKeys(Context.Guild.Id, modal.UserKey, modal.APIToken, modal.BoardId);
        //    await RespondAsync("Trello setup completed!", ephemeral: true);
        //}

        [ModalInteraction("submit_trello_setup")]
        public async Task ModalResponce(SetupTrelloModal modal)
        {
            //await DataAccessLayer.SetTrelloKeys(Context.Guild.Id, modal.UserKey, modal.APIToken, modal.BoardId);

            //GuildTrelloKey guildKeys = DataAccessLayer.GetTrelloKeys(Context.Guild.Id);

            //if (guildKeys != null)
            //{
            //    await RespondAsync("Trello setup completed!", ephemeral: true);
            //}

            //await RespondAsync("Trello setup failed to save, try again.", ephemeral: true);
        }
    }
}
