using Bloxmod.ApiLibrary.Models;

namespace Bloxmod.ApiLibrary.Interfaces.Trello
{
    public interface ITrelloCardService
    {
        Task<TrelloCard> CreateTrelloCardAsync(string cardName, string description, string boardId,
            string listId, string apiKey, string apiToken);
    }
}
