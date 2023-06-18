using Bloxmod.ApiLibrary.Interfaces.Trello;

namespace Bloxmod.ApiLibrary
{
    public class TrelloLibrary
    {
        private const string ApiKey = "7272528ec39706835a95489a712b1dea";
        private const string ApiToken = "78c8e5ace174ddedb182b9050bd9f595b0485f3652c2b7e54ff957ee1536dd1c";
        private const string BoardId = "Alb8phsJ";

        private readonly ITrelloCardService _cardService;
        private readonly ITrelloListService _listService;

        public TrelloLibrary(ITrelloCardService trelloCardService,
            ITrelloListService trelloListService)
        {
            _cardService = trelloCardService;
            _listService = trelloListService;
        }

        public async Task CreateBanCard(string username, int userId)
        {
            var cardName = username + ":" + userId;
            var description = "This user was banned by Bloxmod";

            var lists = await _listService.GetListsByBoardIdAsync(BoardId, ApiKey, ApiToken);
            var banList = lists.FirstOrDefault(list => list.name == "Ban List");

            await _cardService.CreateTrelloCardAsync(cardName, description, BoardId, banList.id, ApiKey, ApiToken);
        }
    }
}
