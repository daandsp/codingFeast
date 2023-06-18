namespace Bloxmod.Models.Modals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Discord.Interactions;

    public class SetupTrelloModal : IModal
    {
        public string Title => "Setup trello for Bloxmod";

        [InputLabel("Trello boardId (step 1)")]
        [ModalTextInput("trello_boardId", placeholder: "Trello board Id", maxLength: 8)]
        public string BoardId { get; set; }

        [InputLabel("Trello Appkey (step 2)")]
        [ModalTextInput("trello_userkey", placeholder: "Your trello Appkey", maxLength: 32)]
        public string UserKey { get; set; }

        [InputLabel("Trello API Token (step 4)")]
        [ModalTextInput("trello_token", placeholder: "Trello API Token", maxLength: 64)]
        public string APIToken { get; set; }
    }
}
