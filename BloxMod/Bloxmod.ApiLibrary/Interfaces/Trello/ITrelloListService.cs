using Bloxmod.ApiLibrary.Models;

namespace Bloxmod.ApiLibrary.Interfaces.Trello
{
    public interface ITrelloListService
    {
        Task<List<TrelloList>> GetListsByBoardIdAsync(string boardId, string apiKey, string apiToken);
    }
}
