using Bloxmod.ApiLibrary.Interfaces.Trello;
using Bloxmod.ApiLibrary.Models;
using RestSharp;

namespace Bloxmod.ApiLibrary.Services.Trello
{
    public class TrelloCardService : ITrelloCardService
    {
        private const string BaseUrl = "https://api.trello.com/1";

        public async Task<TrelloCard> CreateTrelloCardAsync(string cardName, string description, string boardId, string listId, string apiKey, string apiToken)
        {
            var url = $"{BaseUrl}/cards?key={apiKey}&token={apiToken}";

            var newCard = new TrelloCard
            {
                name = cardName,
                pos = "top",
                desc = description,
                idBoard = boardId,
                idList = listId,
            };

            var client = new RestClient(url);
            var request = new RestRequest();

            request.AddBody(newCard);
            var response = await client.PostAsync(request);
            var createdCard = Newtonsoft.Json.JsonConvert.DeserializeObject<TrelloCard>(response.Content);

            return createdCard;
        }
    }
}
