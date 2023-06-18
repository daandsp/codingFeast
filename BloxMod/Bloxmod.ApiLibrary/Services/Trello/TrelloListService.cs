using Bloxmod.ApiLibrary.Interfaces.Trello;
using Bloxmod.ApiLibrary.Models;
using RestSharp;

namespace Bloxmod.ApiLibrary.Services.Trello
{
    public class TrelloListService : ITrelloListService
    {
        private const string BaseUrl = "https://api.trello.com/1";

        public async Task<List<TrelloList>> GetListsByBoardIdAsync(string boardId, string apiKey, string apiToken)
        {
            var url = $"{BaseUrl}/boards/{boardId}/lists?key={apiKey}&token={apiToken}";

            var client = new RestClient(url);
            var request = new RestRequest();

            var response = await client.GetAsync(request);

            if (response == null)
            {
                return null;
            }

            var createdCard = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TrelloList>>(response.Content);

            return createdCard;
        }

    }
}
